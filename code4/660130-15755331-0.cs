    public MyForm()
    {
       this.InitializeComponent();
        
       // Wire up your event handlers.
       foreach (Control ctrl in this.Controls)
       {
          if (ctrl is Label)
          {
             // Wire all Label controls up to do one thing.
             ctrl.MouseClick += new MouseEventHandler(LabelControls_MouseClick);
          }
          else if (ctrl is Button)
          {
             // Wire up all Button controls to do another thing.
             ctrl.MouseClick += new MouseEventHandler(ButtonControls_MouseClick);
          }
          else
          {
             // And wire up the rest of the controls to do a third thing.
             ctrl.MouseClick += new MouseEventHandler(OtherControls_MouseClick);
          }
       }
    }
    
    private void LabelControls_MouseClick(object sender, MouseEventArgs e)
    {
       // do something when a Label control is clicked
    }
    private void ButtonControls_MouseClick(object sender, MouseEventArgs e)
    {
       // do something when a Button control is clicked
    }
    
    private void OtherControls_MouseClick(object sender, MouseEventArgs e)
    {
       // do something when a control other than a Label or Button is clicked
    }
