    public class TestingClass
    {
        public string Prop1 { get; set; }//properties
        public string Prop2 { get; set; }
        public void Method1(string a) { }//method
        public TestingClass() { }//const
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            foreach (System.Reflection.PropertyInfo property in obj.GetType().GetProperties())
            {                
                sb.Append(property.Name);
                sb.Append(": ");
                try
                {
                    sb.Append(property.GetValue(obj, null));
                }
                catch (System.Reflection.TargetParameterCountException)
                {
                    sb.Append("Indexed Property cannot be used");
                }
                
                sb.Append(System.Environment.NewLine);
            }
            return sb.ToString();
        }
    }
