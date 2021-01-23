    protected void Button1_Click(object sender, EventArgs e) 
    {
     string strBidType = "";
     foreach(ListItem cBox in chklBidType.Items) 
     {
       if(cBox.Selected) 
       {
        strBidType += cBox.Value + " / ";
       }
     }
     Response.Write(strBidType);
    }
