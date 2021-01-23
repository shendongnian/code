    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class MySqlColName : Attribute
    {
        private string _name = "";
        public string Name { get => _name; set => _name = value; }
        public MySqlColName(string name)
        {
            _name = name;
        }
    }
