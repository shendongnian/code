    foreach (var x in xs)
    {
        var ys = GetValuesForX(x);
        int limit = int.MaxValue; // Any value is fine to start with.
        foreach (var y in ys)
        {
            if (y > limit)
            {
                break;
            }
            if (y < 100)
            {
                // Take some action 
            }
            limit = y + 30;
        }
    }
