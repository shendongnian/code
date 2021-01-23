    public interface IImplementsM()
    {
      void M();
    }
    
    public class MyA : IImplementsM 
    {
       private A _a;
    
       public MyA(A a){
         _a = a;
       }
    
       public void M(){
         _a.M();
       }
    
    }
