    public Form1()
    {
        InitializeComponent();
        AllowDrop = true;
        DragOver += new DragEventHandler(Form1_DragOver);
    }
    void Form1_DragOver(object sender, DragEventArgs e)
    {
        var stringData = e.Data.GetData(typeof(string));
        MessageBox.Show(stringData);
    }
