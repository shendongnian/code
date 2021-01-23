    protected void fv_OnItemDeleted(Object sender, FormViewDeletedEventArgs e)
    {
 
        if (e.Exception == null)
        {
            if (e.AffectedRows == 1)
            {
                lblMessage.Text="Record deleted successfully.";
            }
            else
            {
                lblMessage.Text = "An error occurred during the delete operation.";
            }
        }
        else
        {
            lblMessage.Text=e.Exception.Message; 
            if(e.Exception.GetType() == typeof(System.StackOverflowException))
                 lblMessage.Text = "Some stackoverflowexception occured, report to admin etc."       
            if(e.Exception.GetType() == typeof(System.ArgumentNullException))
                 lblMessage.Text = "Some argument exception occured"
            e.ExceptionHandled = true;
        }
        UserMessage.Visible = true; // Display Error message to user
    }
