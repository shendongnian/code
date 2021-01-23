     public class DataClass 
     { 
        public string Timestamp { get; set; }
        private static DataClass instance; 
        private DataClass() { }
        public static DataClass Instance 
        {
            get 
            {
                if(instance==null) 
                { 
                    instance = new DataClass(); 
                } 
                 return instance; 
            } 
        }  
    }
    public class Class1
    {
         public void SetValue(string str)
         {
             DataClass ds = DataClass.Instance();
             ds.Timestamp  = "value1";
         }
    }
    public class Class2
    {
         public string GetValue(string str)
         {
             DataClass ds = DataClass.Instance();
             return ds.Timestamp;
         }
    }
    Class1 c1 = new Class1();
    c1.SetValue("hello");
    Class2 c2 = new Class2();
    string value = c2.GetValue();
