    void Main()
    {
    	var ret = new List<Element>();
    	ret.Add(new Element(){ID=1});
    	ret.Add(new Element(){ID=1});
    	ret.Add(new Element(){ID=2});
    	ret = ret.GroupBy(x=>x.ID).Select(x=>x.First()).ToList();
    	Console.WriteLine(ret.Count()); // shows 2
    }
    
    public class Element
    {
      public int ID;
      public int Type;
      public Properties prorerty; 
    }
    
    public class Properties
    {
      public int Id;
      public string Property;
    
    }
