    //Ensure the item is disabled    
    rblRating.Items[0].Enabled = false;
    //Ensure the item is not selected
    rblRating.Items[0].Selected = false;
    //next row of code is hiding your radio button list item through css
    rblRating.Items[0].Attributes[HtmlTextWriterStyle.Visibility] = "hidden";
