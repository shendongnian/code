    //creates an object that will represent the desired mailbox
    Mailbox mb = new Mailbox(common.strInboxURL);
    //creates a folder object that will point to inbox fold
    FolderId fid = new FolderId(WellKnownFolderName.Inbox, mb);
    //this will bind the mailbox you're looking for using your service instance
    Microsoft.Exchange.WebServices.Data.Folder inbox = Microsoft.Exchange.WebServices.Data.Folder.Bind(service, fid);
    SearchFilter.SearchFilterCollection searchFilterCollection = new SearchFilter.SearchFilterCollection(LogicalOperator.And);
    searchFilterCollection.Add(new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
    // exclude any silly returned emails
    searchFilterCollection.Add(new SearchFilter.Not(new SearchFilter.ContainsSubstring(EmailMessageSchema.Subject, "Undeliverable")));
    searchFilterCollection.Add(new SearchFilter.Not(new SearchFilter.ContainsSubstring(EmailMessageSchema.Subject, "Out of Office")));
    ItemView view = new ItemView(100);
    view.OrderBy.Add(ItemSchema.DateTimeReceived, SortDirection.Ascending);
    // This results in a FindItem operation call to EWS.
    FindItemsResults<Item> results = service.FindItems(fid, searchFilterCollection, view);
    if (results.Count() > 0)
       {
       // set the prioperties we need for the entire result set
       view.PropertySet = new PropertySet(
       BasePropertySet.IdOnly,
       ItemSchema.Subject,
       ItemSchema.DateTimeReceived,
       ItemSchema.DisplayTo, EmailMessageSchema.ToRecipients,
       EmailMessageSchema.From, EmailMessageSchema.IsRead,
       EmailMessageSchema.HasAttachments, ItemSchema.MimeContent,
       EmailMessageSchema.Body, EmailMessageSchema.Sender,
       ItemSchema.Body) { RequestedBodyType = BodyType.Text };
       // load the properties for the entire batch
       service.LoadPropertiesForItems(results, view.PropertySet);
        forech (Microsoft.Exchange.WebServices.Data.Attachment attachment in email.Attachments)
            {
            if (attachment is FileAttachment)
                {
                FileAttachment fileAttachment = attachment as FileAttachment;
