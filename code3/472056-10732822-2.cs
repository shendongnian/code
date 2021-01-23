    int i;
    try
    {
        i = int.Parse("a");
    }
    catch
    {
        i = int.Parse("b");
    }
    finally
    {
       Console.Write(i);
    }
