    void Main()
    {
      List<ItemElement> items = new List<ItemElement>() { 
               new ItemElement() { aField = 1 },
               new ItemElement() { aField = 2 },
               new ItemElement() { aField = 3 },
               new ItemElement() { aField = 4 },
               new ItemElement() { aField = 5 },
               new ItemElement() { aField = 6 },
               new ItemElement() { aField = 7 },
               new ItemElement() { aField = 8 },
               new ItemElement() { aField = 9 }
      };
      var result = 
        items.Aggregate(
          // object that will hold items
          new {  
            cols = new List<ItemElement>[3] { new List<ItemElement>(), 
                                              new List<ItemElement>(), 
                                              new List<ItemElement>(), },
            next = 0 },
         // aggregate
         (o, n) => {
           o.cols[o.next].Add(n);
                    
           return new {
             cols = o.cols,
             next = (o.next + 1) % 3
           };
        });
      result.Dump();
    }
      
    public class ItemElement 
    {
       public int aField { get; set; }
    }
