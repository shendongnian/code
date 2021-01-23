    class InterfaceSerializer<T> : MessagePackSerializer<T>
    {
        private Dictionary<string, IMessagePackSerializer> _serializers;
        public InterfaceSerializer()
            : this(SerializationContext.Default)
        {
        }
        public InterfaceSerializer(SerializationContext context)
        {
            _serializers = new Dictionary<string, IMessagePackSerializer>();
            // Use reflection to get all classes that implement T interface
            var shipableTypes = System.Reflection.Assembly
                .GetExecutingAssembly()
                .DefinedTypes
                .Where(t => t.ImplementedInterfaces.Contains(typeof(T)));
            // Create serializer for each class and store it in dictionary
            foreach (var type in shipableTypes)
            {
                var key = type.Name;
                var value = MessagePackSerializer.Create(type, context);
                _serializers.Add(key, value);
            }
        }
        protected override void PackToCore(Packer packer, T objectTree)
        {
            IMessagePackSerializer serializer;
            var typeName = objectTree.GetType().Name;
            if (_serializers.TryGetValue(typeName, out serializer))
            {
                packer.PackArrayHeader(2);             // We send to packer an array of two elements:
                packer.PackString(typeName);           //  - Type name
                serializer.PackTo(packer, objectTree); //  - And packed object
            }
        }
        protected override T UnpackFromCore(Unpacker unpacker)
        {
            IMessagePackSerializer serializer;
            string typeName;
            // Get type name
            if (!unpacker.ReadString(out typeName))
            {
                throw new SerializationException("Cannot get message type");
            }
            // Get serializer
            if (!_serializers.TryGetValue(typeName, out serializer))
            {
                throw new SerializationException("Unknown message type");
            }
            // Next element will be our object
            if (!unpacker.Read())
            {
                throw new SerializationException("Message does not contain an object");
            }
            // Unpack it and return
            return (T)serializer.UnpackFrom(unpacker);
        }
    }
