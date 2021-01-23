    using System.Data;
    DataTable table = new DataTable(); // <-- temp. in memory table of data
    table.Columns.Add("col1");
    table.Rows.Add("some data");
    myDataGridView.DataSource = table;
    myDataGridView.DataBind();
