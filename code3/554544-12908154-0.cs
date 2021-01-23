    public class service()
    {
       private IBaseRepository<MyClass1> _repo;
    
       public  service(IBaseRepository<MyClass1> repo)
       { 
           _repo = repo;
       } 
    
       public void MyMethod()
       {
    
          var x = _repo.MethodFromIBaseRepository()
       }
    
    }
