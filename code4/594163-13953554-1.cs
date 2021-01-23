    try
    {
        double.Parse(str, out dbl);
    }
    catch (Exception ex)
    {
        // Do something with ex.Message
        dbl = 0.0;
    }
    // Continue with dbl.
