    string connectString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\\data\\exceltest.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"";
            OleDbConnection conn = new OleDbConnection(connectString);
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From [Sheet1$]", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            SqlConnection sqlc = new SqlConnection(@"server=.\SQLEXPRESS;user id=sa;pwd=windows;database=exceltest");
            sqlc.Open();
            SqlCommand cmd = new SqlCommand("select * from table1", sqlc);
            SqlDataAdapter sda = new SqlDataAdapter("select * from table1", sqlc);
            sda.InsertCommand = new SqlCommand("insert into table1", sqlc);
            DataTable dbset = new DataTable();
            da.Fill(dbset);
            SqlCommand cmdinsert = new SqlCommand();
            cmdinsert.Connection = sqlc;
            foreach (DataRow dsrc in dt.Rows)
            {
                string insertcommand = "insert into table1" + dbset.TableName + " ";
                string cols = "";
                string vals = "";
                DataRow dr = dbset.NewRow();
                foreach (DataColumn clm in dt.Columns)
                {
                    dr[clm.ColumnName] = dsrc[clm.ColumnName].ToString(); ;
                    if (cols.Length > 0)
                    {
                        cols += ",[" + clm.ColumnName+"]";
                    }
                    else
                    {
                        cols = "["+clm.ColumnName+"]";
                    }
                    if (vals.Length > 0)
                    {
                        vals += "," + "'" + dsrc[clm.ColumnName].ToString() + "'";
                    }
                    else
                    {
                        vals = "'" + dsrc[clm.ColumnName].ToString() + "'";
                    }
                    
                }
                insertcommand += "(" + cols + ") values("+vals+")";
                cmdinsert.CommandText = insertcommand;
                cmdinsert.ExecuteNonQuery();
                insertcommand = "";
            }
            sqlc.Close();
