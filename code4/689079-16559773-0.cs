    public class Filters
    {
      public List<_FiltA> FilterA {get; set;}
      public List<_FiltB> FilterB {get; set;}
      public List<_FiltC> FilterC {get; set;}
      public List<_FiltD> FilterD {get; set;}
    }
    
    ...
    
    [WebMethod]
    public Filters Search(string p1,int p2 ...)
    {
      return new Filters {
        FilterA = _FiltA(someParameters),
        FilterB = _FiltB(someParameters),
        FilterC = _FiltC(someParameters),
        FilterD = _FiltD(someParameters),
      };
    }
