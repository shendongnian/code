    public Form1()
    {
        InitializeComponent();
        form2 = new Form2();
        form2.Show(this);     //pass 'this' as argument to Show() to link them
        form2.Resize += new EventHandler(a_Resize);
    }
