    cn.Open();
    SqlCommand sqlCmd = new SqlCommand();
    sqlCmd.Connection = cn;
    sqlCmd.CommandType = CommandType.Text;
    sqlCmd.CommandText = "INSERT INTO Ticket(CustomerID, Date, Store, Amount, NoStub)  
                           VALUES (@CustomerID, @Date, @Store, @Amount, @NoStub) ";
    sqlCmd.Parameters.AddWithValue("@CustomerID", cboName.SelectedValue);
    sqlCmd.Parameters.AddWithValue("@Date", dtpDate.Value.Date.ToString());
    sqlCmd.Parameters.AddWithValue("@Store", txtStore.Text);
    sqlCmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
    sqlCmd.Parameters.AddWithValue("@NoStub", txtStub.Text);
    sqlCmd.ExecuteNonQuery();
    cn.Close();
