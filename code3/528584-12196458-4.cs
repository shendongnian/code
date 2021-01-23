    protected void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView grid = (GridView)sender;
            DataTable tblProfiles = getProfiles();
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                String header = grid.Columns[i].HeaderText;
                if (header.Length != 0)
                {
                    DataRow drProfile = tblProfiles.AsEnumerable()
                        .FirstOrDefault(p => p.Field<String>("Profile_Name") == header);
                    if (drProfile != null)
                        e.Row.Cells[i].ToolTip = drProfile.Field<String>("Tool_Tip");
                }
            }
        }
    }
    private DataTable getProfiles()
    {
        // assuming SQL-Server
        var connectionString = "blah";
        using (var con = new SqlConnection(connectionString))
        {
            var sql = "SELECT Profile_Name, Tool_Tip FROM Profiles;";
            using (var da = new SqlDataAdapter(sql, con))
            {
                var tblProfiles = new DataTable("Profiles");
                da.Fill(tblProfiles);
                return tblProfiles;
            }
        }
    }
