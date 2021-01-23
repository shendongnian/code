    public void FillDropDownList(string Query, ComboBox DropDownName)
    {
        // If you use a DataTable (or any object which implmenets IEnumerable)
        // you can bind the results of your query directly as the 
        // datasource for the ComboBox. 
        DataTable dt = new DataTable();
        // Where possible, use the using block for data access. The 
        // using block handles disposal of resources and connection 
        // cleanup for you:
        using (var cn = new SqlConnection(CONNECTION_STRING))
        {
            using(var cmd = new SqlCommand(Query, cn))
            {
                cn.Open();
                try
                {
                    var dr = cmd.ExecuteReader();
                    dt.Load(dr);
                }
                catch (SqlException e)
                {
                    // Do some logging or something. 
                    MessageBox.Show("There was an error accessing your data. DETAIL: " + e.ToString());
                }
                finally
                {
                    cn.Close();
                }
            }
        }
        DropDownName.DataSource = dt;
        DropDownName.ValueMember = dt.Columns[0].ColumnName;
        DropDownName.DisplayMember = dt.Columns[1].ColumnName;
    }
