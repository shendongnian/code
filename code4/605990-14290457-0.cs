    public class Foo
    {
        public Dictionary<string, object> CodeMap;
        public int Status
        {
            get 
            {
                int status;
                if (int.TryParse(CodeMap["stat"].ToString(), out status))
                {
                    return status;
                }
                else
                {
                    throw new Exception("Status has a non-numeric value");
                }
            }
            set 
            { 
                CodeMap["stat"] = value; 
            }
        }
        public Foo()
        {
            CodeMap = new Dictionary<string, object>();
        }
    }
