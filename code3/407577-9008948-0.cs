    public override string Text {
      get {
        return base.Text;
      }
      set {
        base.Text = value;
        if (this.Parent != null)
          this.Parent.Invalidate(this.Bounds, false);        
      }
    }
