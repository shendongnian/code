    using System.Data;
    DataTable table = new DataTable(); // <-- temp. in memory table of data
    table.Columns.Add("col1");
    table.Rows.Add("some data");
    table.Rows.Add("some more data");
    table.Rows.Add("and more");
    myDataGridView.DataSource = table;
    myDataGridView.DataBind();
