    public UserControl2() {
      InitializeComponent();
      Loaded += (sender, args) => {
        var obj = (ViewMod)this.DataContext;
        if (obj == null || obj.Prop == null)
          return;
        var d = obj.Prop;
        if (d == null)
          return;
        grd2.Children.Add(new TextBlock { Text = d.Name });
      };
    }
