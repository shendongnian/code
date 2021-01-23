    [XmlIgnore]
    public List<int> AlertColors { get; set; } = new List<int>() { Color.White.ToArgb(), Color.Yellow.ToArgb(), Color.Red.ToArgb() });
            
    [XmlElement(ElementName = "AlertColors")]
    public long[] Dummy
    {
          get
          {
              return AlertColors.ToArray();
          }
          set
          {
              if(value != null) AlertColors = new List<int>(value);
          }
    }
