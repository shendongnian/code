    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DbFieldAttribute : Attribute
    {
        private string fieldName = "";
        public DbFieldAttribute() { }
        public DbFieldAttribute(string fieldName)
        {
            this.fieldName = fieldName;
        }
        public string FieldName(PropertyInfo pi)
        {
            if (this.fieldName != "") return this.fieldName;
            else return pi.Name;
        }
        public string FieldName(FieldInfo fi)
        {
            if (this.fieldName != "") return this.fieldName;
            else return fi.Name;
        }
