    public static void main() { 
        MyClass1 obj = new MyClass1();
        obj.c2.c3.SomeEvent += obj_SomeEvent;      
        obj.Method1();
    }
    private static void obj_SomeEvent(object sender, EventArgs e)             
    {             
        Console.WriteLine("Some event fired");             
    }
    public class MyClass1() {
        public MyClass2 c2 = new MyClass2();
        public void Method1() {
            c2.Method1();
        }
    }
    public class MyClass2() {
       public MyClass3 c3 = new MyClass3();
       public void Method1() {
           c3.Method1();
       }
    }
    public class MyClass3() {
        public event EventHandler SomeEvent;
        private void OnSomeEvent() 
        { 
            if (SomeEvent!= null) 
            { 
                SomeEvent(this, new EventArgs()); 
            } 
        } 
       public void Method1() {
           OnSomeEvent();    
       }
    }
