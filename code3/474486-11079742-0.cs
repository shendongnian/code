       static List<DateTime> lstBookedDates;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lstBookedDates = new List<DateTime>();
                lstBookedDates.Add(DateTime.Today);
                lstBookedDates.Add(DateTime.Today.AddDays(2));
                lstBookedDates.Add(DateTime.Today.AddDays(-2));
                lstBookedDates.Add(DateTime.Today.AddMonths(1));
                lstBookedDates.Add(DateTime.Today.AddMonths(1).AddDays(2));
            }
        }
    
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (lstBookedDates.Where(a=> e.Day.Date.ToShortDateString().Equals(a.Date.ToShortDateString())).Count()>0)
            {
                foreach (Control c in e.Cell.Controls)
                {
                    if (typeof(LiteralControl) == c.GetType())
                    {
    
                        LiteralControl c1 = (LiteralControl)c;
                        c1.Text = "";
                    }
                }
                e.Cell.BackColor = System.Drawing.Color.Gray;
                e.Cell.ToolTip = "Booking full";
                e.Cell.Enabled = false;
                
            }        
        }
