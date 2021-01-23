    string query = "SELECT unitId,unitName FROM unit";
    DataSet ds = new DataSet();
    sqlopen();//a function for check open or close sql connection
    // you must set already sqlConnection for sqlCon parameter
    SqlCommand cmd = new SqlCommand(query, sqlCon); 
    cmd.CommandType = CommandType.Text;
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataSet ds = new DataSet();
    da.Fill(ds, "tbl");
    cbEdit.DataSource = ds.Tables["tbl"];
    cbEdit.DisplayMember = "unitName";
    cbEdit.ValueMember = "unitId";
