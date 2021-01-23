    public Form1()
    {
        InitializeComponent();
        Listen(this);
    }
    
    List<TextBox> textboxes = new List<TextBox>();
    void Listen(Control ctrl)
    {
        foreach (Control ctrl2 in ctrl.Controls)
        {
            if (ctrl2 is TextBox) textboxes.Add(ctrl2 as TextBox);
            foreach (Control ctrl3 in ctrl2.Controls) Listen(ctrl3);
        }
    
        foreach (TextBox tb in textboxes) tb.TextChanged += tb_TextChanged;
    }
    
    void tb_TextChanged(object sender, EventArgs e)
    {
        //Do things...
    }
