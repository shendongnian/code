    DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter("SELECT Customer.CustomerID,             Customer.lastname, Customer.firstname, Ticket.Date, Ticket.Store, Ticket.Amount, Ticket.NoStub " +
                                                    "FROM Customer INNER JOIN Ticket ON Customer.CustomerID = Ticket.CustomerID WHERE Customer.CustomerID like " + txtCustomerID.Text + " order by Ticket.Date desc", cn);
            adp.Fill(dt);
            gvHistory.DataSource = dt;
