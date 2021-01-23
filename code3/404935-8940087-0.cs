    public ControlDecorator(Control c)
    { 
      InitializeComponent();
      this.Control = c;
      this.Control.MouseClick += new MouseEventHandler(Control_MouseClick);
    }
