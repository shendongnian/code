    public Window1(System.Data.DataView datasource)
      {  
          InitializeComponent();
          dataGrid1.ItemsSource = datasource;
          dataGrid1.SelectionMode = DataGridSelectionMode.Single;
          dataGrid1.SelectionUnit = DataGridSelectionUnit.FullRow;
      }
