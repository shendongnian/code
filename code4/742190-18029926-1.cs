    public Form1()
    {
        InitializeComponent();
        Task task = new Task(() => this.GetPivotedDataTable("x",DateTime.UtcNow,1,"test"));
        task.Start();
    }
    public void GetPivotedDataTable(string data, DateTime date, int id, string flag)
    {
        // Do stuff
    }
