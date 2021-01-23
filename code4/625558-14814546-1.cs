    try
    {
        var image = new DImage(@"C:\Test.img");
    }
    catch (System.IO.FileNotFoundException e)
    {
        // The image could not be found.
    }
    catch (Exception e)
    {
        // Something else happened.
    }
