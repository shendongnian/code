    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        //Is it a GridDataItem
        if (e.Item is GridDataItem)
        {
            //Get the instance of the right type
            GridDataItem dataBoundItem = e.Item as GridDataItem;
    
            //Check the formatting condition
            if (int.Parse(dataBoundItem["typedestickets"].Text) =="INDEF")
            {
                dataBoundItem["typedestickets"].ForeColor = Color.Red;
                dataBoundItem["typedestickets"].Font.Bold = true;
                //Customize more...
            }
        }
    }
