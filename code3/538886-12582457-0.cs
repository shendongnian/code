        public class SharePoint
            {
                internal void SPUploader(Stream fs, string fn)
                 {
                    ClientContext context = new ClientContext("http://Sharepointsite");///SitePages/Home.aspx");
                    System.Net.ICredentials creds = System.Net.CredentialCache.DefaultCredentials;
        
                    context.Credentials = creds;
                    context.RequestTimeout = 60000000; // Time in milliseconds
        
                    string url = "/Members/";
                    string fileName = Path.GetFileName(fn);                   
        
                    string fnUrl = url + fn;
        
                    Microsoft.SharePoint.Client.File.SaveBinaryDirect(context, fnUrl, fs, true);
        
                    string uniqueRefNo = GetNextDocRefNo();
                   
                    SP.Web web = context.Web;
        
                    Microsoft.SharePoint.Client.File newFile = web.GetFileByServerRelativeUrl(fnUrl);
                    context.Load(newFile);
                    context.ExecuteQuery();
        
                    Web site = context.Web;
                    List docList = site.Lists.GetByTitle("Members");
        
                    context.Load(docList);
                    context.ExecuteQuery();
        
    
                    context.Load(docList.Fields.GetByTitle("Workflow Number"));
                    context.Load(docList.Fields.GetByTitle("Agreement Number"));
                    context.Load(docList.Fields.GetByTitle("First Name"));
                    context.Load(docList.Fields.GetByTitle("Surname"));
                    context.Load(docList.Fields.GetByTitle("ID Number"));
                    context.Load(docList.Fields.GetByTitle("Date of Birth"));
                    context.Load(docList.Fields.GetByTitle("Country"));
                    context.Load(docList.Fields.GetByTitle("Document Description"));
                    context.Load(docList.Fields.GetByTitle("Document Type"));
                    context.Load(docList.Fields.GetByTitle("Document Group"));
        
                    context.ExecuteQuery();                                
        
    *********NEED TO GET THE INTERNAL COLUMN NAMES FROM SHAREPOINT************
                    var name = docList.Fields.GetByTitle("Workflow Number").InternalName;
                    var name2 = docList.Fields.GetByTitle("Agreement Number").InternalName;
                    var name3 = docList.Fields.GetByTitle("First Name").InternalName;
                    var name4 = docList.Fields.GetByTitle("Surname").InternalName;
                    var name5 = docList.Fields.GetByTitle("ID Number").InternalName;
                    var name6 = docList.Fields.GetByTitle("Date of Birth").InternalName;
                    var name7 = docList.Fields.GetByTitle("Country").InternalName;
                    var name8 = docList.Fields.GetByTitle("Document Description").InternalName;
                    var name9 = docList.Fields.GetByTitle("Document Type").InternalName;
                    var name10 = docList.Fields.GetByTitle("Document Group").InternalName;
                    var name11 = docList.Fields.GetByTitle("Unique Document Ref No").InternalName;     
        
    **********NOW SAVE THE METADATA TO SHAREPOINT**********
                    newFile.ListItemAllFields[name] = "927015";
                    newFile.ListItemAllFields[name2] = "1234565";
                    newFile.ListItemAllFields[name3] = "Joe";
                    newFile.ListItemAllFields[name4] = "Soap";
                    newFile.ListItemAllFields[name5] = "7502015147852";
                    newFile.ListItemAllFields[name6] = "1975-02-01";
                    newFile.ListItemAllFields[name7] = "ZA";
                    newFile.ListItemAllFields[name8] = "Test";
                    newFile.ListItemAllFields[name9] = "Requirements";
                    newFile.ListItemAllFields[name10] = "Requirements";
                    newFile.ListItemAllFields[name11] = uniqueRefNo;
        
                    newFile.ListItemAllFields.Update();
                    context.Load(newFile);
                    context.ExecuteQuery();
