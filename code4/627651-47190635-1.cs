    public Form1()
    {
        InitializeComponent();
        dgv.Columns.Add(new DataGridViewTextBoxColumn());
        dgv.Rows.Add("text");
        dgv.PreviewKeyDown += (sender, args) =>
        {
            Debug.Print(args.KeyCode.ToString());
        };
    }
