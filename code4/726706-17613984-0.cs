    public class Car
    {
        public string Make { get; set; }
        public object this[string name]
        {
            get
            {
                var property = this.GetType().GetProperties().FirstOrDefault(p => p.Name.Equals(name));
                if (property != null)
                {
                    return property.GetValue(this, null);
                }
                return null;
            }
            set
            {
                var property = this.GetType().GetProperties().FirstOrDefault(p => p.Name.Equals(name));
                if (property != null)
                {
                    property.SetValue(this, value, null);
                }
            }
        }
    }
