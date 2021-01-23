    string json = "
    { daily:[
      { key: '1337990400000', val:443447 },
      { key: '1338076800000', val:444693 },
      { key: '1338163200000', val:452282 },
      { key: '1338249600000', val:462189 },
      { key: '1338336000000', val:466626 }]
    }";
    
    public class itemClass
    {
      public string key; // or int
      public int val;
    }
    
    public class items
    {
      public itemClass[] daily;
    }
    
    items daily = (new JavascriptSerializer()).Deserialize<items>(json);
