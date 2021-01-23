    var a = new[] { 
        new { code = "A", subid = 1 }, 
        new { code = "A", subid = 2 }, 
        new { code = "A", subid = 3 },
        new { code = "B", subid = 1 }, 
        new { code = "B", subid = 2 }, 
        new { code = "B", subid = 3 }
    };
    var c = new[] { 
        new { code = "A", subid = 1 }, 
        new { code = "A", subid = 2 },
        new { code = "B", subid = 1 }, 
        new { code = "B", subid = 2 }
    };
    foreach(vat item in a.Except(c))
        Console.WriteLine(item);
    // { code = A, subid = 3 }
    // { code = B, subid = 3 }
