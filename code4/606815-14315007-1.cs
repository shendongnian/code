    public class Car {
    
        private Engine engine; //PRIVATE  
    
        protected Engine MyEngine {   //PROTECTED PROPERTY
            get {
                if(engine == null) 
                   engine = new Engine(); 
                return engine;
            }
        }
    }
