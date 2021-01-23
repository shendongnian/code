    // Get the linklabel object and check for non nullity
    LinkLabel lblItem = e.Item.FindControl("Item") as LinkLabel
    
    if(lblitem !=null)
    {
    // add properties to it 
    lblItem.Attributes.Add("onclick", "this.style.background='#eeff00'");
    
    }
     
