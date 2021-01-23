    public class Test
    {
        public string MyVar{get;set;}
            
        public Test(){ }
    
        public string GetValue()
        {
            return String.Empty;
        }
    }
    //somewere else 
    Test t = new Test();
    t.MyVar = t.GetValue();
