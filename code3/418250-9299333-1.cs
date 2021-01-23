    public class TestingClass
            {
                public string Prop1 { get; set; }//properties
                public string Prop2 { get; set; }
                public void Method1(string a) { }//method
                public TestingClass() { }//const
                public override string ToString()
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (System.Reflection.PropertyInfo property in this.GetType().GetProperties())
                    {
                        sb.Append(property.Name);
                        sb.Append(": ");
                        sb.Append(property.GetValue(this, null));
                        sb.Append(System.Environment.NewLine);
                    }
                    return sb.ToString();
                }
            }
