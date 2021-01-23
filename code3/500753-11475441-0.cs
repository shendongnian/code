    String finalString;
    var tblPieData = new DataTable();
    using(var con = new OdbcConnection(connectionString))
    using (OdbcDataAdapter da = new OdbcDataAdapter("SELECT * FROM pie_data WHERE Pie_ID = ?", con))
    {
        da.SelectCommand.Parameters.AddWithValue("Pie_ID", reference_id);
        da.Fill(tblPieData);
        var rowFields = tblPieData.AsEnumerable()
                                  .Select(r => string.Join(",", r.ItemArray));
        finalString = string.Join("|", rowFields);
    }
