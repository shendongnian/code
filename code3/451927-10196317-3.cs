    private void allTicketsSubmitButton_Click(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT u.CallerName, t.* FROM users u INNER JOIN tickets t ON u.id = t.user";
            GetData(sqlQuery); // move this here, you only need this in one place
    
            if (allTicketsAllRadioButton.Checked)
            {
                ticketsBindingSource.Filter = "ProblemStatus LIKE '%'";
            }
    
            if (allTicketsClosedRadioButton.Checked)
            {
                ticketsBindingSource.Filter = "ProblemStatus = 'Closed'";
            }
    
            if (allTicketsOpenRadioButton.Checked)
            {
                ticketsBindingSource.Filter = "ProblemStatus = 'Open'";               
            }
        }
