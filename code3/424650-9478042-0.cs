    public partial class ThisAddIn
    {
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        this.Application.ItemSend += new Microsoft.Office.Interop.Outlook.ApplicationEvents_11_ItemSendEventHandler(ThisApplication_ItemSend);
    }
    private void ThisApplication_ItemSend(object item, bool cancel)
    {
        Outlook.MailItem newEmail = item as MailItem;
        if (newEmail != null)
        {
            foreach (var attachment in newEmail.Attachments)
            {
                attachment.SaveAsFile(@"C:\TestFileSave\" + attachment.FileName);
            }
        }
    }
    }
    
