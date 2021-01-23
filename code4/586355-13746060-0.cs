    private static DataGrid dataGrid;
    private static myForm myInstance;
    public myForm()  
    {
      InitializeComponent();
      myInstance = this; // set 'myInstance' before DataGrid1 stuff
      DataGrid1.Height = 524;
      DataGrid1.Width = 468;
      DataGrid1.CurrentCellChanged += new EventHandler(dataGrid_CurrentCellChanged);
    }
    public static DataGrid DataGrid1 {
      get {
        try {
          if ((myInstance == null) || myInstance.IsDisposed) {
            throw new Exception("myForm is already disposed. No controls available.");
          }
          if ((dataGrid == null) || dataGrid.IsDisposed) {
            dataGrid = new DataGrid();
            dataGrid.Location = pt;
            dataGrid.Font.Name = "Tahoma";
            dataGrid.Font.Size = 9;
            dataGrid.BackgroundColor = Color.Azure;
            dataGrid.GridLineColor = Color.Black;
            dataGrid.ColumnHeadersVisible = false;
            dataGrid.RowHeadersVisible = false;
            dataGrid.PreferredRowHeight = 60;
            this.Controls.Add(dataGrid);
          }
        } catch (Exception err) {
          Console.WriteLine(err); // put a breakpoint HERE
        }
        return dataGrid;
      }
      set {
        try {
          if ((myInstance == null) || myInstance.IsDisposed) {
            throw new Exception("myForm is already disposed. No controls available.");
          }
          if ((dataGrid == null) || dataGrid.IsDisposed) {
            dataGrid = new DataGrid();
            dataGrid.Location = pt;
            dataGrid.Font.Name = "Tahoma";
            dataGrid.Font.Size = 9;
            dataGrid.BackgroundColor = Color.Azure;
            dataGrid.GridLineColor = Color.Black;
            dataGrid.ColumnHeadersVisible = false;
            dataGrid.RowHeadersVisible = false;
            dataGrid.PreferredRowHeight = 60;
            this.Controls.Add(dataGrid);
          }
        } catch (Exception err) {
          Console.WriteLine(err); // put a breakpoint HERE
        }
        dataGrid = value;
      }
    }
