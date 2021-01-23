    using Microsoft.SharePoint;
    using Microsoft.SharePoint.WebPartPages;
    
    // Get a reference to a web and a list
    SPSite site = new SPSite("http://localhost:8000");
    SPWeb web = site.OpenWeb();
    SPList list = web.Lists["Contacts"];
    
    // Instantiate the web part
    ListViewWebPart wp = new ListViewWebPart();
    wp.ZoneID = "Left";
    wp.ListName = list.ID.ToString("B").ToUpper();
    wp.ViewGuid = list.DefaultView.ID.ToString("B").ToUpper();
    
    // Get the web part collection
    SPWebPartCollection coll = 
    	web.GetWebPartCollection("default.aspx", 
    	Storage.Shared);
    
    // Add the web part
    coll.Add(wp);
 
