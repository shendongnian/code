    "1847".IsInt32(); // true
    "18o2".IsInt32(); // false
    
    var a = "1847".AsInt32();
    a.HasValue; //true
    var b = "18o2".AsInt32();
    b.HasValue; // false;
    
    "18o2".ToInt32(); // with throw an exception since it can't be parsed.
