    [OnSerializing]
    private void OnSerializing(StreamingContext ctx)
    {
        try
        {
            this.SetBits(GetBits(this));
        }
        catch (ArgumentException exception)
        {
            throw new SerializationException(Environment.GetResourceString("Overflow_Decimal"), exception);
        }
    }
    
     
