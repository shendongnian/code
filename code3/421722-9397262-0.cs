    public SeparatorLabel() {
      base.Margin = new Padding(5, 0, 5, 0);
    }
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Padding Margin {
      get { return base.Margin; }
      set {
        throw new Exception("This property is read only.");
      }
    }
