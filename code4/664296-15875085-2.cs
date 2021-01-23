    protected void Page_Load(object sender, EventArgs e)
            {
             if(!IsPostback)
             visitDateCal.SelectedDate = DateTime.Today; //defaults to today's date
            }
