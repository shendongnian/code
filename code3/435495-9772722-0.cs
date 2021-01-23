    try
    {
        try
        {
            sqlCommandWithdraw.Connection.Open();
            sqlCommandWithdraw.Parameters["@cardNumber"].Value = Class1.cardNumber;
            // Make sure to dispose of the reader, which also closes the reader, which
            // is important, because you can't perform any other selects on a connection
            // with an open reader!
            using (SqlDataReader reader = sqlCommandWithdraw.ExecuteReader())
            {
                // You will only get one line - also, your code also only evaluates
                // one result, so we can do the following:
                if (reader.Read())
                {
                    balanceDB = decimal.Parse(readdata["balance"].ToString());
                }
            }
        }
        finally
        {
            sqlCommandWithdraw.Connection.Close();
        }
        decimal withdrawAmm = Convert.ToDecimal(textWithdraw.Text);
        balanceDB = balanceDB - withdrawAmm;
        try
        {
            sqlCommandUpdate.Connection.Open();
            sqlCommandUpdate.Parameters["@cardNumber"].Value = Class1.cardNumber;
            sqlCommandUpdate.Parameters["@balanceDB"].Value = balanceDB;
        
            sqlCommandUpdate.ExecuteNonQuery();
            MessageBox.Show(balanceDB +" Successfully Withdrawn");
        }
        finally
        {
            sqlCommandUpdate.Connection.Close();
        }
}
