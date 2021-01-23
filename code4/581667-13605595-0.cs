         SPList List = Web.Lists["LinksList"];
    
         SPQuery Query = new SPQuery();
         Query.Query = "<OrderBy><FieldRef Name='Title' Ascending='False' /></OrderBy>"
    ArrayList values = new ArrayList();
    
    foreach (SPListItem oItem in oList.GetItems(Query))
    {
    values.Add(oItem.Url);
    
    // You might need to add extra code here to get the full path if you need to such as spweb url etc..
    
    }
    RPTLinks.DataSource = values;
    
    RPTLinks.DataBind();
           
     
