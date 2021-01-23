    public Form1()
    {
        InitializeComponent();
        UserControl cc = new UserControl();
        Panel pp = new Panel();
        pp.Controls.Add(cc);
        pp.ControlRemoved += new ControlEventHandler(pp_ControlRemoved);
        pp.Controls.Clear();
    }
    void pp_ControlRemoved(object sender, ControlEventArgs e)
    {
        var control = sender as MyVerySpecialControl;
        if (control != null)
        {
            //stop timers or unassign events
        }
    }
