    class POCO
    {
    [Flags]
    enum POCOFieldsEnum
    {
      Property1 = 0x01;
      Property2 = 0x02;
    }
    private String _Property1;
    public String Property1 
    { 
      get { return _Property1; }
      set 
      { 
        if (value.Equals(_Property1)) return;
        _Property1 = value;
        DirtyFlags |= POCOFieldsEnum.Property1;
      }
    }
    
    private String _Property2;
    public String Property2
    {
      get { return _Property2; }
      set 
      { 
        if (value.Equals(_Property2)) return;
        _Property2 = value;
        DirtyFlags |= POCOFieldsEnum.Property2;
      }
    }
    
    POCOFieldsEnum DirtyFlags { private set; public get; }
    }
