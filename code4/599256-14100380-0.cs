    protected void Page_Init(object sender, EventArgs e)
    {
        GridViewCommandColumn column = new GridViewCommandColumn("....");
        column.DeleteButton.Visible = true;
        column.DeleteButton.Image.Url = "set path here";
        column.Visible = true;
        column.VisibleIndex = 2;//place where you want it to display
        ASPxGridView1.Columns.Add(column); 
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       // Bind Data here
        BindData();
    }
