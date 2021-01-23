    // Always use (using) when dealing with Sql Connections and Commands
    using (sqlConnection conn = new SqlConnection())
    {
        conn.Open();
        using (SqlCommand newCmd = conn.CreateCommand(conn))
        {
            newCmd.CommandType = CommandType.Text;
            newCmd.CommandText = 
                  @"INSERT INTO tblContracts (CreatedById, CreationDate, EmployeeId, Role, ContractType, StartDate, EndDate, Agency, LineManager, ReportTo, CostCenter, FunctionEng, AtrNo, AtrDate, PrNo, PrDate, PoNo, PoDate, Comments, Duration, WorkRatePercent, Currency, HourlyRate, Value) 
                  VALUES (@UserID, @CreationDate, @EmployeeID, @Role.....etc)";
            // for security reasons (Sql Injection attacks) always use parameters
            newCmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 50)
                 .Value = connectedUser.getUserId();
            newCmd.Parameters.Add("@CreationDate", SqlDbType.DateTime)
                 .Value = DateTime.Now;
            
            // To add a decimal value from TextBox
            newCmd.Parameters.Add("@SomeValue", SqlDbType.Decimal)
                 .Value = System.Convert.ToDecimal(txtValueTextBox.Text);
            // complete the rest of the parameters
            // ........
            newCmd.ExecuteNonQuery();
            MessageBox.Show("Contract has been successfully created", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
