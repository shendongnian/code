    [DataContract]
    public class TestClass
    {
      public Encoding TheEncoding { get; set; }
    
      [DataMember]
      public string TheEncodingName
      {
        get
        {
          if (this.TheEncoding == System.Text.Encoding.UTF8)
            return "utf-8";
          // TODO: More possibilities
        }
        set
        {
          if (value == "utf-8")
            this.TheEncoding = System.Text.Encoding.UTF8;
          // TODO: More possibilities
        }
      }
    }
