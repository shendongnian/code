    public Form1()
    {
        InitializeComponent();
    
        var lastColorSaved = Color.Empty;
                
        foreach(Control child in this.Controls)
        {
            child.Enter += (s, e) =>
                                {
                                    var control = (Control)s;
                                    lastColorSaved = control.BackColor;
                                    control.BackColor = Color.Red;
                                };
            child.Leave += (s, e) =>
                                {
                                    ((Control)s).BackColor = lastColorSaved;
                                };
        }
    }
