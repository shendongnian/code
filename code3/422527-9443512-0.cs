           public static DataTable columnNamessheet1(String excelFile)
        {
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFile + ";Extended Properties='Excel 12.0;HDR=yes'";
            string connectionstring ="Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DebitCare;Data Source=SSDEV7-HP\\SQLEXPRESS";
       
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                SqlConnection SqlConn1 = new SqlConnection(connectionstring);
                SqlConn1.Open();
                OleDbCommand odc = new OleDbCommand(string.Format("Select LoanNumber,CustomerName,DateofBirth,MobileNo,SanctionDate,EmployerName FROM [BAJAJ DUMP$]"), conn);
                conn.Open();
                OleDbDataReader reader = odc.ExecuteReader();               
                DataTable sheetSchema = reader.GetSchemaTable();
                SqlBulkCopy sqlbulk = new SqlBulkCopy(SqlConn1);
                sqlbulk.DestinationTableName = "CUSTOMER_DETAILS";
                sqlbulk.ColumnMappings.Add("LoanNumber", "CUSTOMER_LOAN_NO");
                sqlbulk.ColumnMappings.Add("CustomerName", "CUSTOMER_ NAME");
                sqlbulk.ColumnMappings.Add("DateofBirth", "CUSTOMER_DOB");
                sqlbulk.ColumnMappings.Add("MobileNo", "CUSTOMER_MOBILE NUMBER");
                sqlbulk.ColumnMappings.Add("SanctionDate", "CUSTOMER_SANCTION DATE");
                sqlbulk.ColumnMappings.Add("EmployerName", "CUSTOMER_COMPANY NAME");
                sqlbulk.WriteToServer(reader);
                conn.Close();
                return sheetSchema;            
              
            }
        }
