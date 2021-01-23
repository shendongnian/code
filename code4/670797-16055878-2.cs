    System.IO.MemoryStream memoryStream;
    try
    {
     memoryStream = new System.IO.MemoryStream();
    //....your code
    }
    finally
    {
    if (memoryStream != null) //this check may be optmized away
        memoryStream.Dispose();
    }
