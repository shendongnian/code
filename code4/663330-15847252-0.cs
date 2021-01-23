                if (dr.GetFieldType(k).ToString() =="System.Int32")
                {
                    rowData[k] = dr.GetInt32(k).ToString();
                }
                else if (dr.GetFieldType(k).ToString() == "System.String")
                {
                    rowData[k] = dr.GetString(k);
                }
                else
                {
                    rowData[k] = dr.GetFieldType(k).ToString();
                }
