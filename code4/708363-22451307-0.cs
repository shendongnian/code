    Microsoft.SharePoint.Client.CamlQuery caml = new Microsoft.SharePoint.Client.CamlQuery();
    caml.ViewXml = @"<View><Query><Where><Eq><FieldRef Name='FileLeafRef'/><Value Type='File'>" + itemname+ "</Value></Eq></Where></Query></View>";
 
    caml.FolderServerRelativeUrl = relativepath;
    Microsoft.SharePoint.Client.ListItemCollection items = list.GetItems(caml);
    clientContext.Load(items);
    clientContext.Credentials = new NetworkCredential("username","password","domain");
    clientContext.ExecuteQuery();
    if (items.Count > 0){item["attribute"]=value;}
