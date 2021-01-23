    private IEnumberable<byte> myBytes = null;
    
    [JsonProperty("BytesArray")]
    public string JsonBytes{
    get{
      return String.Join("",myBytes.Select(b=>b.ToString("X2"))); // this may need tweaking, null checks etc
    }
    set{
      byte[] bytes = StringToByteArray(value);
      myBytes = bytes;
    }
    public static byte[] StringToByteArray(string hex) {
    return Enumerable.Range(0, hex.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                     .ToArray();
    }
    
    [JsonIgnore]
    public IEnumerable<byte> BytesArray{
      get{ return myBytes;}
      set{ myBytes = value;}
    }
