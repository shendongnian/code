    [XmlIgnore]
    public List<int> AlertColors { get; set; } = new List<int>() { Color.White.ToArgb(), Color.Yellow.ToArgb(), Color.Red.ToArgb() });
            
    [XmlArray(ElementName = "AlertColors")]
    public long[] Dummy
    {
          get
          {
              return AlertColors.ToArray();
          }
          set
          {
              if(value != null && value.Length > 0) AlertColors = new List<int>(value);
          }
    }
