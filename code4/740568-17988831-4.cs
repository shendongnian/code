    var l = new int[] { 1, 2, 3, 4, 4, 4, 1, 1, 2, 3, 4, 4 };
    var k = new Nullable<int>();
    var nl = l.Where(x => { var res = x != k; k = x; return res; }).ToArray();
    
    int[8] { 1, 2, 3, 4, 1, 2, 3, 4 }
