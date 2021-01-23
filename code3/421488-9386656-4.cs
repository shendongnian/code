    public class AttributedDependencyInjector
    {
        /// <summary>
        /// The component context.
        /// </summary>
        private readonly IComponentContext context;
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributedDependencyInjector"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AttributedDependencyInjector(IComponentContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Injects dependencies into an instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        public void InjectDependencies(object instance)
        {
            this.InjectAttributedFields(instance);
            this.InjectAttributedProperties(instance);
        }
        /// <summary>
        /// Gets the injectable fields.
        /// </summary>
        /// <param name="instanceType">
        /// Type of the instance.
        /// </param>
        /// <param name="injectableFields">
        /// The injectable fields.
        /// </param>
        private static void GetInjectableFields(
            Type instanceType, ICollection<Tuple<FieldInfo, InjectDependencyAttribute>> injectableFields)
        {
            const BindingFlags BindingsFlag =
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            IEnumerable<FieldInfo> fields = instanceType.GetFields(BindingsFlag);
            // fields
            foreach (FieldInfo field in fields)
            {
                Type fieldType = field.FieldType;
                if (fieldType.IsValueType)
                {
                    continue;
                }
                // Check if it has an InjectDependencyAttribute
                var attribute = field.GetAttribute<InjectDependencyAttribute>(false);
                if (attribute == null)
                {
                    continue;
                }
                var info = new Tuple<FieldInfo, InjectDependencyAttribute>(field, attribute);
                injectableFields.Add(info);
            }
        }
        /// <summary>
        /// Gets the injectable properties.
        /// </summary>
        /// <param name="instanceType">
        /// Type of the instance.
        /// </param>
        /// <param name="injectableProperties">
        /// A list into which are appended any injectable properties.
        /// </param>
        private static void GetInjectableProperties(
            Type instanceType, ICollection<Tuple<PropertyInfo, InjectDependencyAttribute>> injectableProperties)
        {
            // properties
            foreach (var property in instanceType.GetProperties(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                Type propertyType = property.PropertyType;
                // Can't inject value types
                if (propertyType.IsValueType)
                {
                    continue;
                }
                // Can't inject non-writeable properties 
                if (!property.CanWrite)
                {
                    continue;
                }
                // Check if it has an InjectDependencyAttribute
                var attribute = property.GetAttribute<InjectDependencyAttribute>(false);
                if (attribute == null)
                {
                    continue;
                }
                // If set to preserve existing value, we must be able to read it!
                if (attribute.PreserveExistingValue && !property.CanRead)
                {
                    throw new BoneheadedException("Can't preserve an existing value if it is unreadable");
                }
                var info = new Tuple<PropertyInfo, InjectDependencyAttribute>(property, attribute);
                injectableProperties.Add(info);
            }
        }
        /// <summary>
        /// Determines whether the <paramref name="propertyType"/> can be resolved in the specified context.
        /// </summary>
        /// <param name="propertyType">
        /// Type of the property.
        /// </param>
        /// <returns>
        /// <c>true</c> if <see cref="context"/> can resolve the specified property type; otherwise, <c>false</c>.
        /// </returns>
        private bool CanResolve(Type propertyType)
        {
            return this.context.IsRegistered(propertyType) || propertyType.IsAssignableFrom(typeof(ILog));
        }
        /// <summary>
        /// Injects dependencies into the instance's fields.
        /// </summary>
        /// <param name="instance">
        /// The instance.
        /// </param>
        private void InjectAttributedFields(object instance)
        {
            Type instanceType = instance.GetType();
            // We can't get information about the private members of base classes through reflecting a subclass,
            // so we must walk up the inheritance hierarchy and reflect at each level
            var injectableFields = new List<Tuple<FieldInfo, InjectDependencyAttribute>>();
            var type = instanceType;
            while (type != null)
            {
                GetInjectableFields(type, injectableFields);
                type = type.BaseType;
            }
            // fields
            foreach (var fieldDetails in injectableFields)
            {
                var field = fieldDetails.Item1;
                var attribute = fieldDetails.Item2;
                if (!this.CanResolve(field.FieldType))
                {
                    continue;
                }
                // Check to preserve existing value
                if (attribute.PreserveExistingValue && (field.GetValue(instance) != null))
                {
                    continue;
                }
                object fieldValue = this.Resolve(field.FieldType, instanceType);
                field.SetValue(instance, fieldValue);
            }
        }
        /// <summary>
        /// Injects dependencies into the instance's properties.
        /// </summary>
        /// <param name="instance">
        /// The instance.
        /// </param>
        private void InjectAttributedProperties(object instance)
        {
            Type instanceType = instance.GetType();
            // We can't get information about the private members of base classes through reflecting a subclass,
            // so we must walk up the inheritance bierarchy and reflect at each level
            var injectableProperties = new List<Tuple<PropertyInfo, InjectDependencyAttribute>>();
            var type = instanceType;
            while (type != typeof(object))
            {
                Debug.Assert(type != null, "type != null");
                GetInjectableProperties(type, injectableProperties);
                type = type.BaseType;
            }
            // Process the list and inject properties as appropriate
            foreach (var details in injectableProperties)
            {
                var property = details.Item1;
                var attribute = details.Item2;
                // Check to preserve existing value
                if (attribute.PreserveExistingValue && (property.GetValue(instance, null) != null))
                {
                    continue;
                }
                var propertyValue = this.Resolve(property.PropertyType, instanceType);
                property.SetValue(instance, propertyValue, null);
            }
        }
        /// <summary>
        /// Resolves the specified <paramref name="propertyType"/> within the context.
        /// </summary>
        /// <param name="propertyType">
        /// Type of the property that is being injected.
        /// </param>
        /// <param name="instanceType">
        /// Type of the object that is being injected.
        /// </param>
        /// <returns>
        /// The object instance to inject into the property value.
        /// </returns>
        private object Resolve(Type propertyType, Type instanceType)
        {
            if (propertyType.IsAssignableFrom(typeof(ILog)))
            {
                return LogManager.GetLogger(instanceType);
            }
            return this.context.Resolve(propertyType);
        }
    }
