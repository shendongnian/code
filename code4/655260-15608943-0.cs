    protected void Page_Load(object sender, EventArgs e)
    {
        blocks = new DataManager().GetBlocks();
        if (!IsPostBack)
        {
            DayPilotCalendar1.StartDate = Week.FirstWorkingDayOfWeek(DayPilotNavigator1.SelectionStart);
            DayPilotCalendar1.Days = 7; 
            DayPilotCalendar1.DataSource = new DataManager().GetAssignments(DayPilotCalendar1);
            DayPilotCalendar1.DataBind();
        }
    }
