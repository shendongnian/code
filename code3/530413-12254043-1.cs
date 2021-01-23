    public static void main() { 
        MyClass3.SomeEvent += obj_SomeEvent;
        MyClass1 obj = new MyClass1();
        obj.Method1();
    }
    private static void obj_SomeEvent(object sender, EventArgs e)             
    {             
         Console.WriteLine("Some event fired");             
    }
    public class MyClass1() {
        public void Method1() {
            MyClass2 obj = new MyClass2();
            obj.Method1();
        }
    }
    public class MyClass2() {
       public void Method1() {
           MyClass3 obj = new MyClass3();
           obj.Method1();
       }
    }
    public class MyClass3() {
        public static event EventHandler SomeEvent;
        private void OnSomeEvent(MyClass3 anObj) 
        { 
            if (SomeEvent!= null) 
            { 
                SomeEvent(anObj, new EventArgs()); 
            } 
        }
 
        public void Method1() {
           OnSomeEvent(this);    
        }
    }
