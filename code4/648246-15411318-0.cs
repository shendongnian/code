    protected void SqlDataSource1_OnInserted(Object source, SqlDataSourceStatusEventArgs e) 
    {
        if (e.AffectedRows > 0)
        {
            // Send e-mail
        }
        else
        {
            // For some reason, the insert didn't happen.  Check for exceptions
            string errorMessage = e.Exception.InnerException.Message;
            // Here you want to display this error to the user, or log it, or something
        }
    }
