    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            DataList1.RepeatColumns = 4; //Initial Rows
            DataList1.RepeatDirection = RepeatDirection.Horizontal;
            DropDownList1.SelectedValue = DataList1.RepeatColumns.ToString();
            //LoadDataList;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataList1.RepeatColumns = Convert.ToInt16(DropDownList1.SelectedValue);
        //LoadDataList;
    }
