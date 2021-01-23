    public class Constants
    {
        static Constants instance;
        public static Constants Instance
        {
            get 
            {
                 if (instance == null) 
                 {
                     instance = new Constants();
                     instance.Initialize();
                 }
            }
        }
    
        public void Initialize()
        {
             // db logic here to populate db recorded fields.
        }
    
        private Constants()
        {
        }
    
    }
