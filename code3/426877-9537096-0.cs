    public void submitInformationToDatabase() {
             using (System.Transactions.TransactionScope tr = new System.Transactions.TransactionScope())
               {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(dbPath);
                con.Open();
                addPatientInformation(con);
                addResponsiblePartyInformation(con);
                tr.Complete();
               }
                MessageBox.Show("Patient Demographics Has Been added.");
            }
