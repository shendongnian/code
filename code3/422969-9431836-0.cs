        using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Filename + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES\""))
        {
            //
            string listName = "Sheet1";
            con.Open();
            try
            {
                DataSet ds = new DataSet();
                OleDbDataAdapter odb = new OleDbDataAdapter("select * from [" + listName + "$]", con);
                odb.Fill(ds);
                con.Close();
                foreach (DataRow myrow in ds.Tables[0].Rows)
                {
                    Object[] cells = myrow.ItemArray;
                    if (cells[0].ToString().Length > 0 || cells[1].ToString().Length > 0 || cells[2].ToString().Length > 0)
                    {
                        /*
                        cells[0]
                        cells[1]
                        cells[2]
                        are getting values
                        */
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
