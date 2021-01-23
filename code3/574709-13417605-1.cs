    var lstX1 = new List<X1> { new X1 { ID = 1, ID1 = 10 }, 
                               new X1 { ID = 10, ID1 = 100 } };
    var lstX2 = new List<X2> { new X2 { ID = 1, ID2 = 20 }, // ID changed here
                               new X2 { ID = 20, ID2 = 200 } };
    
    var a5 = lstX1.Cast<X>().Union(lstX2.Cast<X>());  // 3 distinct items
    var a6 = lstX1.Cast<X>().Concat(lstX2.Cast<X>()); // 4
