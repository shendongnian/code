    public Form1()
    {
      InitializeComponent();
      ElementHost host= new ElementHost();
      host.Size = new Size(200, 100);
      host.Location = new Point(100,100);
      AvalonEditControl edit = new AvalonEditControl();
      host.Child = edit;
      this.Controls.Add(host);
    }
