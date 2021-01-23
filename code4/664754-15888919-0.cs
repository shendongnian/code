    ArrayList al = Session["selectedValues"] as ArrayList;
    
    if(al != null)
    {
        foreach(var item in al)
        {
            invoiceListBox.Items.Add(new ListItem {Value = item.toString(), Text = item.toString()});
        }
    }
