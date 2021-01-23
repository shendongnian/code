    private void button2_Click(object sender, EventArgs e)
    {
            // put your SqlConnection into a using block
            using (SqlConnection conn = new SqlConnection(@"Data Source HERE"))
            {
                // define query with parameters
                string queryStmt = "INSERT INTO dbo.mainTab(Token_number, ItemType, Quantity, Amount) " +
                                   "VALUES(@TokenNumber, @ItemType, @Quantity, @Amount)";
                // put your SqlCommand into a using block
                using (SqlCommand cmd = new SqlCommand(queryStmt, conn))
                {
                    // Add parameter definitions to SqlCommand
                    cmd.Parameters.Add("@TokenNumber", SqlDbType.Int);
                    cmd.Parameters.Add("@ItemType", SqlDbType.Int);
                    cmd.Parameters.Add("@Quantity", SqlDbType.Decimal);
                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                    int rn = 0;
                    
                    // now open - as late as possible!
                    conn.Open();
                    // iterate
                    while (rn < dgvmain.Rows.Count)
                    {
                        // set parameter values
                        cmd.Parameters["@TokenNumber"].Value = Convert.ToInt32(dgvmain.Rows[rn].Cells[0].Value);
                        cmd.Parameters["@ItemType"].Value = Convert.ToInt32(dgvmain.Rows[rn].Cells[1].Value);
                        cmd.Parameters["@Quantity"].Value = Convert.ToDecimal(dgvmain.Rows[rn].Cells[2].Value);
                        cmd.Parameters["@Amount"].Value = Convert.ToDecimal(dgvmain.Rows[rn].Cells[3].Value);
                        // execute INSERT statement
                        cmd.ExecuteNonQuery();
                        rn++;
                    }
                    conn.Close();
                }
            }
    }
 
