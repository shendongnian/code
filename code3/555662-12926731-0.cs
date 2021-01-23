    public delegate void DelegateWithRefParameters(ref int i, ref long l, ref bool b, ref object o);
    
    public class Program
    {
        public static void Main(string[] args)
        {
            int i = 0;
            long l = 0;
            bool b = false;
            object o = null;
            
            var lookup = new Dictionary<string, DelegateWithRefParameters>() 
            {
                { "object", ModifyObject },
                { "int", ModifyInt },
                { "bool", ModifyBool },
            };
            
            string s = "object";
            
            lookup[s](ref i, ref l, ref b, ref o);
        }
        
        private static void ModifyObject(ref int i, ref long l, ref bool b, ref object o)
        {
            o = new object();
        }
        
        private static void ModifyInt(ref int i, ref long l, ref bool b, ref object o)
        {
            i++;
        }
        
        private static void ModifyBool(ref int i, ref long l, ref bool b, ref object o)
        {
            b = !b;
        }              
        
    }
