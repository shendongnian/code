    MyObject myvar = myStream.ReadMyObject();
    if (dataProcessor.Process(ref myvar)) {.... }
    // Data processor....
    public Boolean Process(ref MyObject myvar)
    {
        if (!myvar.IsClean)
        {
            myvar = new MyObject(); // Create clean object
            return false;
        }
        return true;
    }
