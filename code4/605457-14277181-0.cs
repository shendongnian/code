    DateTime darkAge = new DateTime(1111, 1, 1);
    if (darkAge >= SqlDateTime.MinValue.Value && darkAge <= SqlDateTime.MaxValue.Value)
    {
        // we're not gettting here since the dark age was before 1753 
    }
