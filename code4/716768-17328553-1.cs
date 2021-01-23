            Dictionary<string, Dictionary<string, string>> nameValues = new Dictionary<string, Dictionary<string, string>>();
            // Deal with all the properties on the object
            IList<PropertyInfo> props = new List<PropertyInfo>(this.GetType().GetProperties());
            foreach (PropertyInfo prop in props)
            {
                Dictionary<string, string> nameValue = new Dictionary<string, string>();
                nameValue.Add("name", prop.Name);
                object propValue = prop.GetValue(this, null);
                if (propValue == null)
                {
                    nameValue.Add("value", string.Empty);
                }
                else
                {
                    nameValue.Add("value", prop.GetValue(this, null).ToString());
                }
                nameValues.Add(prop.Name, nameValue);
            }
            Dictionary<string, object> nameValuesArray = new Dictionary<string, object>();
            nameValuesArray.Add("name_value_list", nameValues);
            string jsonString = JsonSerializer.SerializeToString<Dictionary<string, object>>(nameValuesArray);
