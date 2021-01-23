       private Dictionary<Integer,List<SeriesClass>> dict= new Dictionary<Integer,List<SeriesClass>>();
    
       public class SeriesClass
        {
    
          public int Value1 { get; set; }
          public string Value2 { get; set; }
    
        }
      Loop that populates the data {
       if ( dict.containsKey(seriesNum) ){
           dict[seriesNum].Add(new SeriesClass { Value1 = value1, Value2 = value2});
       }else{
          var list = new List<SeriesClass>();
          list.Add(new SeriesClass { Value1 = value1, Value2 = value2} );
          dcm.Add(seriesNum, list);
       }
    }
