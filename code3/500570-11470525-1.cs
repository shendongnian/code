     OdbcCommand broadcastSelect = new OdbcCommand("select * from exchange where status='1' and type='UPDATE'", cloud);
            OdbcDataReader DbReader = Select.ExecuteReader();
            int fCount = DbReader.FieldCount;
            String type = "";
            String filename = "";
            byte[] data = null;
            int status = 0;
            OdbcParameter param = null;
            while (DbReader.Read())
            {
                if (DbReader.IsDBNull(0))
                {
                    type = "BLANK";
                }
                else
                {
                    type = (string)DbReader[0];
                }
                if (DbReader.IsDBNull(1))
                {
                    filename = "BLANK";
                }
                else
                {
                    filename = (string)DbReader[1];
                }
                if (DbReader.IsDBNull(2))
                {
                    param = new OdbcParameter("@file", SqlDbType.Binary);
                    param.DbType = DbType.Binary;
                    param.Value = new byte[1];                
                    command.Parameters.Add(param); 
                }
                else
                {
                    param = new OdbcParameter("@file", SqlDbType.Binary);
                    param.DbType = DbType.Binary;
                    param.Value = (byte[])dbReader[2];
                    param.Size = ((byte[])dbReader[2]).Length; 
                    command.Parameters.Add(param); 
                }
                if (DbReader.IsDBNull(3))
                {
                    status = 0;
                }
                else
                {
                    status = (int)DbReader[3];
                }
    
                OdbcCommand Copy = new OdbcCommand("INSERT INTO exchange(type,filename,data,status) VALUES('" + type + "','" + filename + "',@file,'" + status + "')", local);
                Copy.ExecuteNonQuery();
