    for (int i = 0; i < (dataGridView2.Rows.Count)-1; i++)
    {
    }
    ConnectionDB gridRdata = new ConnectionDB("SELECT * FROM Ready_Made_Master");
    DataTable redydata = gridRdata.returntable();
    gridRdata .Datasource=redydata ;
    gridRdata .Databind();
