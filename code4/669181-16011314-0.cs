        public static T Field<T>(this object source, string FieldName)
        {
            var type = source.GetType();
            var field = type.GetField(FieldName);
            return (T)field.GetValue(source);
        }
