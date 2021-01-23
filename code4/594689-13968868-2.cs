    public DropDownList GetAll(string SortDirection, string SortExpression, DropDownList list)
    {
      //  var list = new DropDownList(); //Remove this line
        list.DataSource = SegmentDL.GetAllSegment(SortDirection, SortExpression);
        list.DataTextField = "_SegmentName";
        list.DataValueField = "_SegmentID";      
        ListItem item = new ListItem();
        item.Text = "--Select--";
        item.Value = "0";
        list.Items.Insert(0, item);
        list.DataBind();
        return list;
    }
