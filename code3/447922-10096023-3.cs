    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        //pass index of item in command argument
        var itemIndex = Convert.ToInt32(e.CommandArgument);      
        //find the pnlChildView control
        var innerPlaceHolder = lstOuterList.Items[itemIndex].FindControl("plcInnerList") as PlaceHolder;
        if (innerPlaceHolder != null)
        {
            innerPlaceHolder.Visible = !innerPlaceHolder.Visible;          
            if (innerPlaceholder.Visible)
            {
                var innerList = innerPlaceHolder.FindControl("lstInnerList") as ListView;
                if (innerList != null)
                {
                    //the id to retrieve data for the inner list
                    int keyValue = (int)lstOuterList.DataKeys[itemIndex]["ID"];
                    //bind the list using DataList1 data key value
                    innerList.DataSource = new DataTable("DataSource"); //your datasource
                    innerList.DataBind();
                }  
            }
        }
    }
