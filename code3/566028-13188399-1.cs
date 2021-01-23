    private void retrieveAccountInformation(out string pin,out string firstname,out double balance)
    {
     //get account info
     try
     {
            myResultSet = myStatement.executeQuery("SELECT pin, " +
           "firstName, balanceAmount FROM accountInformation " +
           "WHERE accountNumber = '" + userAccountNumber + "'");
            //get next result
            if (myResultSet.next())
            {
                pin = myResultSet.getString("pin");
                firstName = myResultSet.getString("firstName");
                balance = myResultSet.getDouble("balanceAmount");
            }
            myResultSet.close(); //close myResultSet
        }//end try
        catch (Exception)
        {
            Console.WriteLine("Error in retrieveAccountInformation");
        }
    }// end method retrieveAccountInformation
    private void buttonBalance_Click(object sender, EventArgs e)
    {
        string pin, firstname;
        double balance;
        retrieveAccountInformation(pin, firstname, double);
        messageTextArea.Text=(balance.ToString());
        //display balance to messageTextArea
    }
