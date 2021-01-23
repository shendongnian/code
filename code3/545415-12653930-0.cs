    private abstract class GlobalQueryParam<TValue> : IGlobalQueryParam where TValue : struct {   
      public readonly TValue Low;   
      public TValue Val;    
      protected TValue dbVal = default(TValue);   
   
      public TValue GetDBVal()   
      {   
        return  dbVal;   
      }   
      . . . implement IGlobalQueryParam . . .
   
    }  
  
    public class GlobalQueryParamInt : GlobalQueryParam<int> {
   
      . . . 
    }
