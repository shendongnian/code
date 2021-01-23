    interface IExecutor{
         void Execute();
    }
    
    public class Command{
         IExecutor _e;
         public Command(IExecutor e){
              _e = e;
         }
    
         public void Do(){
            _e.Execute();
         }
    }
    
    
    public class Command<T> where T : IExecutor{
         public Command(T e){
              _e = e;
         }
    
         public void Do(){
            _e.Execute();
         }
    }
