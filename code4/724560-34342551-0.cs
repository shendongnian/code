    public static void main() {
        SomeClassFactory factory = new SomeClassFactory();
        
        // putting the parsing in the factory expresses the
        // association of the enum to its target types.
        SomeClassEnum someClassName = SomeClassFactory.Parse(xmlInput);
        BaseType someClassInstance = factory.Create(someClassName);
    }
    
    public class SomeClassFactory{
        // Potentially throws NotImplementedException
        public static SomeClassEnum Parse (string xmlInput) { ... }
        
        // the type is already resolved, so we don't need to do
        // it again in any of the code called herein.
        public SomeClassBase Create (SomeClassEnum thisClassName) {
            BaseType newInstance;
            switch(thisClassName) { 
                case SomeClassEnum.TypeA:
                    newInstance = buildTypeA();
                    break;
                // ...
            }
            return newInstance;
        }
    }
