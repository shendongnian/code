      public Class abstract  Base<T>
      {
        public abstract List<T>GetList();
      }
    then do this 
    
      public class className:Base<ObjectName>
      {
      public override List<T>GetList()
      {
        //do work here 
      }
    
    }
