         public void UpdateDescription(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    String dataDesc = dr["DataDesc"].ToString(); 
                    if (!dr.IsNull("DataDesc"))
                    {
                        if (dataDesc.Contains("STATE"))
                        {
                            dataDesc = dataDesc.Replace("STATE", "").Trim();
                        }
                        if (dataDesc.Contains("HELLO ALL"))
                        {
                            dataDesc = dataDesc.Replace("HELLO ALL", "").Trim();
                        }
                        if (dataDesc.Contains("("))
                        {
                            dataDesc = dataDesc.Remove(dataDesc.IndexOf("(")).Trim();
                        }
                    }
                    dr["DataDesc"] = dataDesc;
                }
            }
        }
