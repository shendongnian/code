    private Color _UnfocusedColor = ColorTranslator.FromHtml(@"#94C7FC");
    private Color _FocusedColor = ColorTranslator.FromHtml(@"#6B6E77");
    public Color UnfocusedColor
    {
       get { return _UnfocusedColor; }
       set { _UnfocusedColor = value; }
    }
    public Color FocusedColor
    {
      get { return _FocusedColor; }
      set { _FocusedColor = value; }
    }
