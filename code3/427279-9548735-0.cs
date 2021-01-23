    public Form1()
    {
        InitializeComponent();
    
        SetControlColoring(this);
    }
    
    private static void SetControlColoring(Form parent)
    {
        var lastColorSaved = Color.Empty;
                
        foreach(Control child in parent.Controls)
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
