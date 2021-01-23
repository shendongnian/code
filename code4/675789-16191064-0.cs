       public interface IMinimalState
       {
          IMinimalState generate();
          int getData();
       }
    
       public interface IState : IMinimalState
       {
          new IState generate();      
          int getAnotherData();
       }
    
       public class State : MinimalState, IState
       {
          public IState generate() { return this; } 
          IMinimalState IMinimalState.generate() { return  generate(); }           
          ...
       }
