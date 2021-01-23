    static public bool IsLightFile(string fileName)
    {
      //Use any with names returned from the enum.
       return Enum.GetNames(typeof(LightFiles)).Any(w => w == fileName);    
    }
