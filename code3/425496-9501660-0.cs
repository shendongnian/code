    ExchangeService service = GetService();
    var view = new ItemView(1);
    var searchFilter = new SearchFilter.IsEqualTo(EmailMessageSchema.Subject, "Some subject text");
    var items = service.FindItems(WellKnownFolderName.Inbox, searchFilter, view);
    service.LoadPropertiesForItems(items, new PropertySet(BasePropertySet.FirstClassProperties, EmailMessageSchema.Attachments));
    var item = items.ElementAt(0) as EmailMessage;
    for (int i = 0; i < item.Attachments.Count; i++)
    {
        var att = item.Attachments[i] as FileAttachment;
        if (att.IsInline && att.ContentType.Contains("image"))
        {
            att.Load(String.Format(@"c:\temp\attachedimage_{0}.jpg", i));
        }
    }
