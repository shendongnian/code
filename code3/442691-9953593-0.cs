    <<**** Global variable **************>>
    Public static int innerRepeaterCount=0;
      
    <<********* Your rptEditInfo_ItemDataBound event wiil be as follows*******>>
  
    protected void rptEditInfo_ItemDataBound(object sender, RepeaterItemEventArgs e) 
    {
        dv = e.Item.DataItem as DataRowView;  
       if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        {
           nestedRCountInInnerR = nestedRCount;
           innerRepeaterCount++; 
        }
     }
     innerRepeaterCount will give you total item counts in inner Repeater
