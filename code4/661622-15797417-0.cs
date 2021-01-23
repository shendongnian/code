    public MainWindow(){
        //...
        Loaded+=(_,e)=>{
             System.Windows.Controls.DataGrid dg = new System.Windows.Controls.DataGrid();
             dg.RowHeaderStyle = (Style)FindResource("newRowHeader");
        };
    }
