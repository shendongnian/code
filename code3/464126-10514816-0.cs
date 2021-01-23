    public static class MyStaticClass 
    {     
        public static MyStaticClass Instance
        {         
             get
                 {             
                      return this; //compile time error!
                 }
        }
    }
