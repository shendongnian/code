    public ChildWindow1()
    {
      InitializeComponent();
      UpdateSize( null, EventArgs.Empty );
      App.Current.Host.Content.Resized += UpdateSize;
    }
    protected override void OnClosed( EventArgs e )
    {
      App.Current.Host.Content.Resized -= UpdateSize;
    }
    private void UpdateSize( object sender, EventArgs e )
    {
      this.Width = App.Current.Host.Content.ActualWidth;
      this.Height = App.Current.Host.Content.ActualHeight;
      this.UpdateLayout();
    }
