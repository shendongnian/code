    public class Result 
    {
      [XmlIgnore]
      public List<ResultData> Data { get; set; }
    
      [XmlElement(ElementName = "gen_info")]
      public ResultData[] __XmlSerializedData{
        get{ return Data.ToArray();}
        set{ Data = new List<ResultData>(value);}
      }
    }
