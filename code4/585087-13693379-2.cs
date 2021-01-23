        private string GetPropertyValue(PropertyDescriptor pd)
        {
            var property = GetPropertyOwner(pd);
            if (property is CustomObject)
            {
                var dataSeries = property as CustomObject;
                // This will return a string of the list contents ("One, Two, Three")
                return string.Join(",", dataSeries.ListProperty.ToArray());
            }
            else if (property is ....)
            {
                return somthing else
            }
            return property.ToString();
        }
