    private IEnumberable<byte> myBytes = null;
    
    [JsonProperty("BytesArray")]
    public List<byte> JsonBytes{
    get{
      return new List<byte>(myBytes);
    }
    set{
      myBytes = value;
    }
    
    [JsonIgnore]
    public IEnumerable<byte> BytesArray{
      get{ return myBytes;}
      set{ myBytes = value;}
    }
