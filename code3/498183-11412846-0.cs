    object A = new object();
    object B = new object();
    int iterations = 1000000000;
    DateTime start = DateTime.Now;
    for (int i = 0; i < iterations; i++)
    {   
        if (A == null)
        {
            A = B;
        }
    }
    DateTime middle = DateTime.Now;
    for (int i = 0; i < iterations; i++)
    {
        A = A ?? B;
    }
    DateTime end = DateTime.Now;
    TimeSpan first = middle.Subtract(start);
    TimeSpan second = end.Subtract(middle);
