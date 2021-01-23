    var curCol = 0;
    var iPer = items.Count() / 3;
    var iLeft = items.Count() % 3;
    var result = items.Aggregate(
                   // object that will hold items
                   new {  
                          cols = new List<ItemElement>[3] { new List<ItemElement>(), 
                                                            new List<ItemElement>(), 
                                                            new List<ItemElement>(), },
                              },
                   (o, n) => {
                     o.cols[curCol].Add(n);
 
                     if (o.cols[curCol].Count() > iPer + (iLeft > (curCol+1) ? 1:0))
                       curCol++;
                   
                     return new {
                       cols = o.cols
                    };
                 });
