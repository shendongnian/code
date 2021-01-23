    // private - don't write to this field from outside the property setter
    static Font font = new Font("Arial", 10.0f));
    public static Font Font
    {
      get
      {
        return font;
      }
      set
      {
        var oldFont = font;
        if (oldFont != null)
          oldFont.Dispose();
        font = value;
      }
    }
