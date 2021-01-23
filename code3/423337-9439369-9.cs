    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["TimeSheetItems"] = GetData();
            BindData();
        }
    }
    
    protected void TimeSheetGrid_RowCancelingEdit(
         object sender
        ,GridViewCancelEditEventArgs e)
    {
        // Exit edit mode - the user clicked cancel
        TimeSheetGrid.EditIndex = -1;
        BindData();
    }
    
    protected void TimeSheetGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Enter edit mode - the user clicked edit
        TimeSheetGrid.EditIndex = e.NewEditIndex;
        BindData();
    }
    
    protected void TimeSheetGrid_RowUpdating(
         object sender
        ,GridViewUpdateEventArgs e)
    {
        var items = (IEnumerable<TimeSheetItem>)Session["TimeSheetItems"];
        // Get the TimeSheetItem that was being edited
        var item = items.Single(i => i.Name.Equals(e.Keys["Name"].ToString()));
        // Set the TimeSheetItem values to the new values
        item.Sunday1 = TryGetIntValue(e.NewValues["Sunday1"]);
        item.Monday1 = TryGetIntValue(e.NewValues["Monday1"]);
        item.Tuesday1 = TryGetIntValue(e.NewValues["Tuesday1"]);
        item.Wednesday1 = TryGetIntValue(e.NewValues["Wednesday1"]);
        item.Thursday1 = TryGetIntValue(e.NewValues["Thursday1"]);
        item.Friday1 = TryGetIntValue(e.NewValues["Friday1"]);
        item.Saturday1 = TryGetIntValue(e.NewValues["Saturday1"]);
        item.Sunday2 = TryGetIntValue(e.NewValues["Sunday2"]);
        item.Monday2 = TryGetIntValue(e.NewValues["Monday2"]);
        item.Tuesday2 = TryGetIntValue(e.NewValues["Tuesday2"]);
        item.Wednesday2 = TryGetIntValue(e.NewValues["Wednesday2"]);
        item.Thursday2 = TryGetIntValue(e.NewValues["Thursday2"]);
        item.Friday2 = TryGetIntValue(e.NewValues["Friday2"]);
        item.Saturday2 = TryGetIntValue(e.NewValues["Saturday2"]);
    
        // Exit from edit mode
        TimeSheetGrid.EditIndex = -1;
    
        // Re-bind the data
        BindData();
    }
    
    private static int TryGetIntValue(object val)
    {
        int intVal;
        Int32.TryParse(val.ToString(), out intVal);
        return intVal;
    }
    
    private void BindData()
    {
        TimeSheetGrid.DataSource = Session["TimeSheetItems"];
        TimeSheetGrid.DataBind();
    }
    
    private IEnumerable<TimeSheetItem> GetData()
    {
        // You can pre-populate the hours here
        return new List<TimeSheetItem>()
        {
             new TimeSheetItem() { Name = "IN1" }
            ,new TimeSheetItem() { Name = "IN2" }
            ,new TimeSheetItem() { Name = "IN3" }
            ,new TimeSheetItem() { Name = "IN4" }
            ,new TimeSheetItem() { Name = "Personal" }
            ,new TimeSheetItem() { Name = "Doctor" }
            ,new TimeSheetItem() { Name = "Other" }
            ,new TimeSheetItem() { Name = "Sick" }
            ,new TimeSheetItem() { Name = "Vacation", Thursday2 = 8 }
            ,new TimeSheetItem() { Name = "Holiday" }
            ,new TimeSheetItem() { Name = "Meeting" }
        };
    }
