    public class TDataElement {
        private TDataElement(){}
        public static TDataElement Create(string name ) {  
            return new TDataElement {
                                       FName = name,
                                       FPersistent = true
                                       // ... other initialization ...
                                    };
        }
        public static TDataElement CreateParam(string name, double defaultDouble){
             var element = Create(name);
             // ... use DefaultInt ...
             return element;
        }
    //...    
    }
