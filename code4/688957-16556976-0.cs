    Outlook.Application oApp = new Outlook.Application();
     
    if (this.listViewContacts.SelectedItems != null &&
    this.listViewContacts.SelectedItems.Count > 0)
    {
    Outlook.ContactItem oRecip = (Outlook.ContactItem)
    (this.listViewContacts.SelectedItems[0].Tag);
     
    Outlook.MailItem email = (Outlook.MailItem)
    (oApp.CreateItem(Outlook.OlItemType.olMailItem));
    email.Recipients.Add(oRecip.Email1Address);
    email.Subject = "Just wanted to say...";
    email.Body = "Have a great day!";
     
    if (MessageBox.Show(
    "Are you sure you want to send a good day message to " +
    oRecip.Email1DisplayName + "?", "Send?",
    MessageBoxButtons.OKCancel)
    == DialogResult.OK)
    {
    try
    {
    ((Outlook.MailItem)email).Send();
    MessageBox.Show("Email sent successfully.", "Sent");
    }
    catch (Exception ex)
    {
    MessageBox.Show("Email failed: " + ex.Message,
    "Failed Send");
    }
    }
     
    oRecip = null;
    email = null;
    }
