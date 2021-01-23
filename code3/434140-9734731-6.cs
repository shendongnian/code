        private void UpgradeDB()
        {
            SqlConnection conn = new SqlConnection("Some Connection String");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = "If 1 = (Select 1 from sysobjects where id = object_id('CheckTables'))\r\n" +
                              "  Drop Table CheckTables\r\n" +
                              "Create Table CheckTables\r\n" +
                              "(oid int,\r\n" +
                              "oname varchar(50),\r\n" +
                              "colid int,\r\n" +
                              "cname varchar(50),\r\n" +
                              "ctype varchar(50),\r\n" +
                              "cxtype int,\r\n" +
                              "tlength int,\r\n" +
                              "cPrec int,\r\n" +
                              "cScale int,\r\n" +
                              "isnullable int";
            cmd.ExecuteNonQuery();
            //BCP your data from MASTER TABLE into the CheckTables of the UpgradeDB
            cmd.CommandText = "Select oname, cname, ctype, IsNull(tlength, 0), IsNull(cprec, 0), IsNull(cscale, 0), isnullable from CheckTables hr\r\n" +
                              "where cname not in (Select name from syscolumns where id = object_id(oname)\r\n" +
                              "and length = hr.tlength\r\n" +
                              "and xusertype = hr.xusertype\r\n" +
                              "and isnullable = hr.isnullable)\r\n" +
                              "order by oname";
            SqlDataReader read = cmd.ExecuteReader();
            string LastTable = "";
            bool TableExists = false;
            bool ColumnExists = false;
            while(read.Read())
            {
                if(LastTable != read[0].ToString())
                {
                    LastTable = read[0].ToString();
                    TableExists = false;
                    if (!CheckIfTableExist(LastTable))
                        TableExists = CreateTable(LastTable);
                    else
                        TableExists = true;
                }
                if (TableExists)
                {
                    if (!CheckIfColumnExists(read[0].ToString(), read[1].ToString()))
                    {
                        CreateColumn(read[0].ToString(), read[1].ToString(), read[2].ToString(),     
                            Convert.ToInt32(read[3].ToString()), Convert.ToInt32(read[4].ToString()), 
                            Convert.ToInt32(read[5].ToString()), Convert.ToBoolean(read[6].ToString()));
                        ColumnExists = false; //You don't want to alter the column if you just created it
                    }
                    else
                        ColumnExists = true;
                    if(ColumnExists)
                    {
                        AlterColumn(read[0].ToString(), read[1].ToString(), read[2].ToString(),  
                            Convert.ToInt32(read[3].ToString()), Convert.ToInt32(read[4].ToString()), 
                            Convert.ToInt32(read[5].ToString()), Convert.ToBoolean(read[6].ToString()));
                    }
                }
            }
            read.Close();
            read.Dispose();
            conn.Close();
            cmd.Dispose();
            conn.Dispose();
        }
        private bool CheckIfTableExist(string TableName)
        {
            SqlConnection conn = new SqlConnection("Connection String");
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Select IsNull(object_id('" + TableName + "'), 0)";
            Int64 check = Convert.ToInt64(cmd.ExecuteScalar());
            conn.Close();
            cmd.Dispose();
            conn.Dispose();
            return check != 0;
        }
        private bool CreateTable(string TableName)
        {
            try
            {
                //Write your code here to create your table
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool CheckIfColumnExists(string TableName, string ColName)
        {
            SqlConnection conn = new SqlConnection("Connection String");
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Select IsNull(id, 0) from syscolumns where id = object_id('" + TableName + "') and name = '" + ColName + "'";
            Int64 check = Convert.ToInt64(cmd.ExecuteScalar());
            conn.Close();
            cmd.Dispose();
            conn.Dispose();
            return check != 0;
        }
        private void CreateColumn(string TableName, string ColName, string ColType, int Length, int Precision, int Scale, bool Nullable)
        {
            //Write your code here to create your column
        }
        private void AlterColumn(string TableName, string ColName, string ColType, int Length, int Precision, int Scale, bool Nullable)
        {
            //Write your code here to alter your column
        }
