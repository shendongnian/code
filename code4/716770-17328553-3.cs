    public class NameValue
    {
        public string name { get; set; }
        public string value { get; set; }
    }
    public class Lead
    {
        public string assigned_user_name { get; set; }
        public string modified_by_name { get; set; }
        public string modified_user_name { get; set; }
        public List<NameValue> toNameValues()
        {
            List<NameValue> nameValues = new List<NameValue>();
            IList<PropertyInfo> props = new List<PropertyInfo>(this.GetType().GetProperties());
            foreach (PropertyInfo prop in props)
            {
                NameValue nameValue = new NameValue();
                object propValue = prop.GetValue(this, null);
                if (propValue != null && !String.IsNullOrEmpty(propValue.ToString()))
                {
                    nameValue.name = prop.Name;
                    nameValue.value = propValue.ToString();
                    nameValues.Add(nameValue);
                }
            }
            return nameValues;
        }
    }
