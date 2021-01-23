    public class Instrument
    {
       // an example enum holding types
       public InstrumentType Type {get; set;}
    
       // x is not a great name, but following your question's convention...
       public double X
       {
          get
          {
             if(type == InstrumentType.Stock)
                return Algo2.y();
                // note that I changed this to be a method rather than a property
                // Algo2.y() should be static so it can be called without an instance
             else if(type == InstrumentType.Future)
                return 5.0;
             else 
                // return some default value here
          }
       }
    }
