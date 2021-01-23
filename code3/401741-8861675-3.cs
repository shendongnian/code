    public Color MyColor
    {
      get
      {
        if(_color == null)
        {
          var c = new Color("red");//allow multiple creations but...
          Interlocked.CompareExchange(ref _color, c, null);//only one write
        }
        return _color;
      }
    }
    
    public Color MyColor
    {
      get
      {
        if(_color == null)
          lock(somelock)
            if(_color == null)
              _color = new Color("red");//allow one creation only
        return _color;
      }
    }
