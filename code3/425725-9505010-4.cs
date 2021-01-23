    public Form1()
    {
        InitializeComponent();
        Listen(this);
    }    
    
    void Listen(Control ctrl)
    {
        foreach (Control ctrl2 in ctrl.Controls)
        {
            if (ctrl2 is TextBox) (ctrl2 as TextBox).TextChanged += tb_TextChanged;
            foreach (Control ctrl3 in ctrl2.Controls) Listen(ctrl3);
        }
    }
    
    void tb_TextChanged(object sender, EventArgs e)
    {
        //Do things...
    }
