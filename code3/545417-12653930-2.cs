    private abstract class GlobalQueryParam<TValue> : IGlobalQueryParam where TValue : struct {   
      public readonly TValue Low;   
      public TValue Val;    
      protected TValue dbVal = default(TValue);   
   
      public TValue GetDBVal()   
      {   
        return  dbVal;   
      }   
      public override string ToString()
      {
        return Val.ToString();
      } // ToString
      . . . implement IGlobalQueryParam . . .
   
    }  
  
    public class GlobalQueryParamInt : GlobalQueryParam<int> {
   
      . . . 
    }
