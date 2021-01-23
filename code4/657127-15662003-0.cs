    public class MyClass {
        private static int staticitem;
        private int instanceitem;
        static MyClass(){
            staticitem = 0; //define value for staticitem
        }
        private MyClass() { //can only be called from within the class
           instanceitem = 0; //define value for instanceitem
        }
  
        public static MyClass GetMyClass() {
           MyClass m = new MyClass();
           return m;
        }    
    }
