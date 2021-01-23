    object[] data = 
    {
        "x1", "y1", 4,
        "x2", "y2", 3,
        "x3", "y3", 2,
        "x4", "y4", 3
    };
    int countPerType = 3;
    int size = data.Length;
    var initMe = new List<BaseType>();
    for (int idx = 0; idx < size; idx += countPerType)
    {
        initMe.Add(
            new DerivedType() 
            { 
                X = (string)data[idx], 
                Y = (string)data[idx + 1], 
                Z = (int)data[idx + 2] 
            });
    }
