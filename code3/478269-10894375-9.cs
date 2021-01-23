    private void BindGrid()
    {
        try
        {
            var tblData = new DataTable();
            var filter1 = TextBox1.Text.Trim();
            var filter2 = TextBox2.Text.Trim();
            using (var sqlCon = new System.Data.SqlClient.SqlConnection(connectionstring))
            {
                String sql = String.Empty;
                var sqlCmd = new System.Data.SqlClient.SqlCommand();
                if (filter1.Length != 0 && filter2.Length != 0)
                {
                    sql = "SELECT Column1,Column2 FROM Table WHERE Column1 LIKE @Column1 AND Column2 LIKE @Column2 ORDER BY {0}";
                    sqlCmd.Parameters.AddWithValue("@Column1", string.Format("%{0}%", filter1));
                    sqlCmd.Parameters.AddWithValue("@Column2", string.Format("%{0}%", filter2));
                }
                else if (filter1.Length != 0)
                {
                    sql = "SELECT Column1,Column2 FROM Table WHERE Column1 LIKE @Column1 ORDER BY {0}";
                    sqlCmd.Parameters.AddWithValue("@Column1", string.Format("%{0}%", filter1));
                }
                else if (filter2.Length != 0)
                {
                    sql = "SELECT Column1,Column2 FROM Table WHERE Column2 LIKE @Column2 ORDER BY {0}";
                    sqlCmd.Parameters.AddWithValue("@Column2", string.Format("%{0}%", filter2));
                }
                else
                {
                    // no filter, select all
                    sql = "SELECT Column1,Column2 FROM Table ORDER BY {0}";
                }
                sqlCmd.CommandText = string.Format(sql, this.SortExpression);
                sqlCmd.Connection = sqlCon;
                using (System.Data.SqlClient.SqlDataAdapter objAdapter = new System.Data.SqlClient.SqlDataAdapter(sqlCmd))
                {
                    objAdapter.Fill(tblData);
                }
            }
            GridView1.DataSource = tblData;
            GridView1.DataBind();
        }
        catch (Exception)
        {
            // log
            throw;
        }
    }
