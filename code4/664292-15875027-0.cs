    protected void Page_Load(object sender, EventArgs e)
    {
    if(!Page.IsPostBack)
    {
        visitDateCal.SelectedDate = DateTime.Today; //defaults to today's date
    }
    }
