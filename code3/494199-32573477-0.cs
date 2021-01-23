            if (rbtnSearchBy1.Checked)
            {
                Server.Transfer("ViewEmpHistory.aspx");
            }
            else if (rbtnSearchBy2.Checked)
            {
                Server.Transfer("SearchEmp.aspx");
            }
            else if (rbtnSearchBy3.Checked)
            {
                Server.Transfer("ViewEmpCard.aspx");
            }
            else
            {
              // Here's where the logic will flow to if no radio button is clicked.
              // We could 
              // * Server.Transfer to a default location
              // * Throw an exception
              // * Do nothing, which returns no response, and causes
              //   IE to complain that it could not display the webpage.
            }
