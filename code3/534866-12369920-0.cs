    DataTable customTable = new DataTable();
            customTable.Columns.Add("Column1");
            customTable.Columns.Add("Column2");
            DataRow drNew = null;
            foreach(DataRow dR in 1stDataSource)
            {
                foreach(DataRow dR1 in 2ndDataSource)
                {
                    if(dR["ID"] == dR1["ID"])
                    {
                        drNew = customTable.NewRow();
                        drNew["Column1"] = dR["Column1"];
                        drNew["Column2"] = dR1["Column2"];
                        customTable.Rows.Add(drNew);
                        break;
                    }
                }
            }
            myDataList.DataSource = customTable;
            myDataList.DataBind();
