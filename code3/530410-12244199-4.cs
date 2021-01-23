    public class MyClass1             
    {             
        public void Method1()             
        {             
            MyClass2 obj = new MyClass2();             
            obj.SomeEvent += obj_SomeEvent;             
            obj.Method1();             
        }             
             
        private static void obj_SomeEvent(object sender, EventArgs e)             
        {             
            Console.WriteLine("Some event fired");             
        }             
    }  
    
    public class MyClass2() 
    {    
       MyClass3 cls3 = new MyClass3();
       
       public void Method1() 
       {     
           cls3.FireSomeEvent();    
       }   
    
        public event MyEventHandler SomeEvent
        { 
            add { this.cls3.SomeEvent += value; } 
            remove { this.cls3.SomeEvent -= value; } 
        }  
    }
    public class MyClass3() 
    {
        public event EventHandler SomeEvent;
    
        private void OnSomeEvent() 
        { 
            if (SomeEvent!= null) 
            { 
                SomeEvent(this, new EventArgs()); 
            } 
        } 
        public void FireSomeEvent
        {
            OnSomeEvent();
        }
    }
