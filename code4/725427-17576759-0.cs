    EmailAddressChooserTask eact = new EmailAddressChooserTask();
    eact.Completed += eact_Completed;
    eact.Show();
    void eact_Completed(object sender, EmailResult e)
    {
        if (e.TaskResult == TaskResult.OK)
        { 
           string selectedEmail = e.Email;
        }
        else
        {
           //nothing chosen
        }      
    }
