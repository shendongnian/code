    public static void StartProcess()
            {
                //Create a local data table to hold customer records
                DataTable dtCustomers = new DataTable("Customers");
                DataColumn dcFirstName = new DataColumn("FirstName", typeof(string));
                DataColumn dcLastName = new DataColumn("LastName", typeof(string));
                DataColumn dcEmail = new DataColumn("Email", typeof(string));
                dtCustomers.Columns.Add(dcFirstName);
                dtCustomers.Columns.Add(dcLastName);
                dtCustomers.Columns.Add(dcEmail);
                //Add customer 1
                DataRow drCustomer = dtCustomers.NewRow();
                drCustomer["FirstName"] = "AAA";
                drCustomer["LastName"] = "XYZ";
                drCustomer["Email"] = "aaa@test.com";
                dtCustomers.Rows.Add(drCustomer);
                //Add customer 2
                drCustomer = dtCustomers.NewRow();
                drCustomer["FirstName"] = "BBB";
                drCustomer["LastName"] = "XYZ";
                drCustomer["Email"] = "bbb@test.com";
                dtCustomers.Rows.Add(drCustomer);
                //Add customer 3
                drCustomer = dtCustomers.NewRow();
                drCustomer["FirstName"] = "CCC";
                drCustomer["LastName"] = "XYZ";
                drCustomer["Email"] = "ccc@test.com";
                dtCustomers.Rows.Add(drCustomer);
                //Create Connection object to connect to server/database
                SqlConnection conn = new SqlConnection(ConStr);
                conn.Open();
                //Create a command object that calls the stored procedure
                SqlCommand cmdCustomer = new SqlCommand("AddToTarget", conn);
                cmdCustomer.CommandType = CommandType.StoredProcedure;
                //Create a parameter using the new SQL DB type viz. Structured to pass as table value parameter
                SqlParameter paramCustomer = cmdCustomer.Parameters.Add("@TargetUDT", SqlDbType.Structured);
                paramCustomer.Value = dtCustomers;
                //Execute the query
                cmdCustomer.ExecuteNonQuery();        
            }
