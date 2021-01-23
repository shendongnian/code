    public void DoSomething(Office.IRibbonControl control)
    {
        var window = plugin.Application.ActiveWindow();
        var attachsel = window.AttachmentSelection();
    
        int? index = null;
        if (attachsel.count > 0)
        {
            var attachment = attachsel[1];
            index = attachment.Index;
        }
        
        var explorer = plugin.Application.ActiveExplorer();
        var selection = explorer.Selection;
    
        if ((selection.Count > 0) && (index != null))   
        {
            object selectedItem = selection[1];
            var mailItem = selectedItem as Outlook.MailItem;
            foreach (Outlook.Attachment attach in mailItem.Attachments)
            {
                if (attach.Index == index)
                {
                    attach.SaveAsFile(Path.Combine(@"c:\temp\", attach.FileName));
                }
            }
    
        }
    }
