    private void CreateNewEmail_Click(object sender, EventArgs e)
    {
        // start a transaction so that all our objects are saved together.
        this.transaction = this.session.BeginTransaction();
        this.currentEmail = new Email();
    }
    
    private void AddAttachment_Click(object sender, EventArgs e)
    {
        var attachment = new Attachment();
        // set the properties.
    
        // Add it to the session so that the identifier is populated (no insert statements are sent at this point)
        this.session.Save(attachment);
    
        // Also add it to the email
        this.currentEmail.Attachments.Add(attachment);
    }
    
    private void SendEmail_Click(object sender, EventArgs e)
    {
        // Commit the transaction (at this point the insert statements will be sent to the database)
        this.transaction.Commit();
    }
