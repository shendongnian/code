    private IEnumberable<byte> myBytes = null;
    
    [JsonProperty("BytesArray")]
    public string JsonBytes{
    get{
      return String.Join("",myBytes.Select(b=>b.ToString("X2"))); // this may need tweaking, null checks etc
    }
    set{
      byte[] bytes = Convert.FromBase64String(value);
      myBytes = bytes;
    } 
    [JsonIgnore]
    public IEnumerable<byte> BytesArray{
      get{ return myBytes;}
      set{ myBytes = value;}
    }
