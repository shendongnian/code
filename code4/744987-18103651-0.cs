    public class MyService {
        
        Func<IUnitOfWork> _dbFunc;
    
        public MyService(Func<IUnitOfWork> makeDbFunc) {
            _dbFunc = makeDbFunc;
        }
    
        public void MyServiceCall(){
    
            using(var disposableDb = (IDisposable)_dbFunc()){
                // Do Work Here
            }
        } 
    }
