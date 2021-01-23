    public class TestClass : IDisposable {
    
       private DataClassesDataContext _dataContext;
    
       public TestClass(string connString){
           _dataContext = new DataClassesDataContext(connString);
        }
    
       private bool someMethod(){
           _dataContext.instanceMethod(); // i want to use instance methods wherever needed and define once
       }
      
       public void Dispose(){
           _dataContext.Dispose();
       }
    }
