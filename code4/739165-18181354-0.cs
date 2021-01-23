            byte attempts = 0;
            
          tryagain:  //Find last invoice no
            OleDbCommand command = new OleDbCommand("SELECT MAX(invoice_id) FROM Invoices"
                     , myconnection);
                int last_invoice_id = 0;
                try
                {
                    last_invoice_id = (int)command.ExecuteScalar();
                }
                catch (InvalidCastException) { };
               // text_invoice_number.Text = Convert.ToString(last_invoice_id + 1);
            
                try
                {
                    command = new OleDbCommand(@"INSERT INTO Invoices
          (invoice_id,patient_id,visit_id,issue_date,invoice_to,doctor_id,assistant_id)
         VALUES(?,?,?,?,?,?,?)",myconnection);
       // We use last_invoice_id+1 as primary key
       command.Parameters.AddWithValue("@invoice_id",last_invoice_id+1);
                // I will add other parameters here (with the exact order in query)
                    command.ExecuteNonQuery();
                }
                catch (Exception ex){
                    attempts++;
                    if (attempts <= 3)  // 3 attempts
                    {
                        System.Threading.Thread.Sleep(300); // 300 ms second delay
                        goto tryagain;
                    }
                    else
                    {
                        MessageBox.Show("Can not add invoice to database, " + ex.Message,   "Unexpected error!"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            for (int i = 0; i <= listInvoiceItems.Count-1; i++)
            {
                   command = new OleDbCommand(@"INSERT INTO Invoices_Items
                                     (invoice_id,quantity,product,price,amount,item_type)
                                            VALUES(?,?,?,?,?,?)",myconnection);
           // Now we use our stored last_invoice_id+1 as foreign key
                 command.Parameters.AddWithValue("@invoice_id",last_invoice_id+1); 
             // Add other Invoice Items parameters here (with the exact order in query)
            command.ExecuteNonQuery();
            }
