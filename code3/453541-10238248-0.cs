    protected myClass(SerializationInfo info, StreamingContext context)
    {
        c = info.GetInt32("Value_C"); 
        try
        {
            b = info.GetBoolean("Value_B");
        }
        catch (SerializationException)
        {
            b = true;
        }
    }
