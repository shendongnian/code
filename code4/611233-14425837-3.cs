    "1847".IsInt32(); // true
    "18o2".IsInt32(); // false
    
    var a = "1847".AsInt32();
    var b = a.IsInt32(); //true
    var b = "18o2".AsInt32();
    var c = b.HasValue; // false;
    
    var d = "18o2".ToInt(); // with throw an exception since it can't be parsed.
