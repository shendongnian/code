    Engine engine = new Engine();
    public Form1()
    {
        InitializeComponent();
        var dt = new DataTable();
        dt.Columns.Add("column0");
        dt.Columns.Add("column1");
        dt.Columns.Add("column2");
        dt.Rows.Add("a", "b", "c");
        engine.DataTable = dt;
        int numberOfDimensions = engine.DataTable.Columns.Count;
        TextBox[] txtBoxArr = new TextBox[numberOfDimensions];
        for (int i = 0; i < numberOfDimensions; i++)
        {
            string tabName = "Dataset" + (i + 1);
            tabCtrlDatasets.TabPages.Add(tabName, tabName);
            txtBoxArr[i] = new TextBox();
            txtBoxArr[i].Name = engine.DataTable.Columns[i].ColumnName;
            txtBoxArr[i].DataBindings.Add("Text", 
                engine.DataTable, txtBoxArr[i].Name);
            tabCtrlDatasets.TabPages[i].Controls.Add(txtBoxArr[i]);
        }
    }
