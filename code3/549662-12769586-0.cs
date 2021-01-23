    var Ij_ = Objects.GetEnumerator();
    while (Ij.MoveNext())
    {
        Test MyBase = IJ_.Current;
        // I understood that you want to skip null elements, so...
        if (MyBase == null)
        {
            continue;
        }
        // ...
    }
