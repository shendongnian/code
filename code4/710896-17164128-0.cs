    void Main()
    {
    
    var ExistIntervals = new HashSet<Interval>();
    //1 Aug 2012 4 Aug 2012
    //5 Aug 2012 11 Aug 2012
    //12 Aug 2012 15 Aug 2012
    ExistIntervals.Add(new Interval { From = new DateTime(2012, 8, 1), 
                                      To = new DateTime(2012, 8, 4) });
    ExistIntervals.Add(new Interval { From = new DateTime(2012, 8, 5), 
                                      To = new DateTime(2012, 8, 11) });
    ExistIntervals.Add(new Interval { From = new DateTime(2012, 8, 12), 
                                      To = new DateTime(2012, 8, 15) });
    
    var QueryIntervals = new HashSet<Interval>();
    //1 Aug 2012 2 Aug 2012 INVALID
    //5 Aug 2012 11 Aug 2012 INVALID
    //10 Aug 2012 10 Aug 2012 VALID
    //15 Aug 2012 15 Aug 2012 INVALID
    QueryIntervals.Add(new Interval { From = new DateTime(2012, 8, 1), 
                                      To = new DateTime(2012, 8, 2) });
    QueryIntervals.Add(new Interval { From = new DateTime(2012, 8, 5), 
                                      To = new DateTime(2012, 8, 11) });
    QueryIntervals.Add(new Interval { From = new DateTime(2012, 8, 10), 
                                      To = new DateTime(2012, 8, 10) });
    QueryIntervals.Add(new Interval { From = new DateTime(2012, 8, 15), 
                                      To = new DateTime(2012, 8, 15) });
    
    var result = QueryIntervals.Where( x=> !ExistIntervals.Any(
                                             y=>(y.From <= x.From && x.From <= y.To)
                                             || (y.From <= x.To && x.To<=y.To)
                                                              )
                                     );
    result.Dump();														   
    
    }
    
    public class Interval
    {
      public DateTime From { get; set; }
      public DateTime To { get; set; }
    }
