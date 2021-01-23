        private void SetVariableFromReader(string variableName)
        {
            var property = GetType().GetProperty(variableName);
            if (property != null)
            {
                if (typeof(string).IsAssignableFrom(property.PropertyType))
                {
                    property.SetValue(this, subReader.ReadElementContentAsString());
                }
                if (typeof(bool).IsAssignableFrom(property.PropertyType))
                {
                    property.SetValue(this, subReader.ReadElementContentAsBool());
                }
                // ...
            }
        }
