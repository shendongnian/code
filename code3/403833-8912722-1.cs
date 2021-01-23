     private void someFunction<T>(List<T> list) where T : MyType, new()
        { 
           /*elementwise reflection stuff*/
    
           var instance = new T();
           Type type = instance.GetType();
           instance.MyMethod();    
        } 
    
        public class MyType
        {        
           public void MyMethod()
           {
            
           }
        }
