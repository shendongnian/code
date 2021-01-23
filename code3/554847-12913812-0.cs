        // Required by ISerializable
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            FieldInfo[] fields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
            {
                if (!IsSerializable(field))
                    continue;
                info.AddValue(field.Name, field.GetValue(this));
            }
        }
        protected bool IsSerializable(FieldInfo info)
        {
            object[] attributes = info.GetCustomAttributes(typeof(SerializableProperty), false);
            if (attributes.Length == 0)
                return false;
            return true;
        }
