     string qrystring = "your query";
                 SqlCommand cmd = new SqlCommand(qrystring, conn);
                 SqlDataAdapter DA = new SqlDataAdapter(qrystring, conn);
                 SqlCommandBuilder scb = new SqlCommandBuilder(DA);
                 DataTable dTable = new DataTable();
                 DA.Fill(dTable);
                 GridView1.DataSource = dTable;
                 GridView1.DataBind();
    
    }
             catch (SqlException)
             {
                 lblnameinfo.Text = "Gridview binding error";
             }
             finally
             {
                 if (conn != null)
                 {
                     conn.Close();
                 }
             }
         }
