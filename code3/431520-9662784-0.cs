    public ReadCache(SerializationInfo info, StreamingContext ctxt)
      : this()
    {
        //Get the values from info and assign them to the appropriate properties
        notifiedURLs = (ArrayList)info.GetValue("notifiedURLs", typeof(ArrayList));
    }
