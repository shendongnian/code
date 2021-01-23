    try
    {
        myCommand.Connection.Open();
        myCommand.ExecuteNonQuery();
        myCommand.Connection.Close();
    }
    catch (Exception ex)
    {
        FormMessage.Text = "Error:SaveBtn_Click - " + ex.Message;
        // no "return;"  !!
    }
    //SendNotification(from, to, cc, subject, body, attach);
    FormMessage.Text = "\n Thank you for leaving anonymous feedback for " + 
                            employee_reviewed; ;
