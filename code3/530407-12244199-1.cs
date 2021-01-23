    public class MyClass2() 
    {    
       MyClass3 cls3;
    
       public void Method1() 
       {    
           cls3 = new MyClass3();    
           cls3.Method1();    
       }   
    
        public event MyEventHandler SomeEvent
        { 
            add { this.cls3.SomeEvent += value; } 
            remove { this.cls3.SomeEvent -= value; } 
        }  
    }
