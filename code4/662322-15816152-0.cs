    namespace MyNameSpace {
    
        public class MyClass {
            public MyClass() {
                // initialise
            }
    
            public static MyClass CreateMyClassFromName() {
                Type myType = Type.GetType("MyNameSpace.MyClass");
                System.Reflection.ConstructorInfo constinfo = myType.GetConstructor(new Type[] { });
                MyClass mc = (MyClass)constinfo.Invoke(null);
                return mc;
            }
    
        }
    
    }
