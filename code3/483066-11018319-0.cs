    public EditRectangle(FormRectangle p)
    {
        InitializeComponent();
        this.p = p;
        textBox1.Text = p.GetMass().ToString();
        textBox2.Text = p.GetHeight().ToString();
        textBox3.Text = p.GetWidth().ToString();
        // SET TRACKBAR'S INDEX TO THE RIGHT PLACE BY p.GetElasticity()
        trackbar.Value = p.GetElasticity();
    }
