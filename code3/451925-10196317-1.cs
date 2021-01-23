    private void allTicketsSubmitButton_Click(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT u.CallerName, t.* FROM users u INNER JOIN tickets t ON u.id = t.user";
    
            if (allTicketsAllRadioButton.Checked)
            {
                GetData(sqlQuery);
                ticketsBindingSource.Filter = "ProblemStatus LIKE '%'";
            }
    
            if (allTicketsClosedRadioButton.Checked)
            {
                GetData(sqlQuery);
                ticketsBindingSource.Filter = "ProblemStatus = 'Closed'";
            }
    
            if (allTicketsOpenRadioButton.Checked)
            {
                GetData(sqlQuery);
                ticketsBindingSource.Filter = "ProblemStatus = 'Open'";               
            }
        }
