     SqlCommand cmd = new SqlCommand(strSql, sqlConn);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                for (int i = 0; i < sdr.FieldCount - 1; i++)
                {
                    string dataTypeName = sdr.GetDataTypeName(i); // Gets the type of the specified column in SQL Server data type format
                    string FullName = sdr.GetFieldType(i).FullName; // Gets the type of the specified column in .NET data type format
                    string specificfullname = sdr.GetProviderSpecificFieldType(i).FullName; //Gets the type of the specified column in provider-specific format
                    //Now print the values
                }            
