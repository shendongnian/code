    //"MainForm"
    
    public static MainForm MainFormRef { get; private set; }
    public Form1()
    {
        InitializeComponent();
        MainFormRef = this;
    }
    
    public void addRowToDataGridView(string type, string title, string time)
    {
      dgvTasks.Rows.Add(type, title, time);
    }
    
    
    //"ParametersForm"
    private void btnSave_Click(object sender, EventArgs e)
    {
      var fm = MainForm.MainFormRef;
      fm.addRowToDataGridView("s1", "s2", "s3");
    }
