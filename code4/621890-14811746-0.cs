    protected void Page_Load(object sender, EventArgs e)
          {
             if (!Page.IsPostBack)
               {
                   eventsDayView.DataLoad(DateTime.Now);
                   calendar.SelectedDate = DateTime.Now;
                   calendar.TodaysDate = DateTime.Now;
                   calendar.VisibleDate = DateTime.Today;
                   addWeekNumberColumn();
                }
          }
    private void addWeekNumberColumn()
          {
            // Get the date shown in the calendar control
            DateTime curMonth = calendar.VisibleDate;
                
            // Find first day of the current month
            curMonth = Convert.ToDateTime(curMonth.Year.ToString() + "-" + curMonth.Month.ToString() + "-01");
                
            // Build javascript
            string jscript = "<script type='text/javascript'> addWkColumn('" + calendar.ClientID + "', " + getISOWeek(curMonth).ToString() + ");</script>";
                
             // Add script to page for execution of addWkColumn javascript function
             Page.ClientScript.RegisterStartupScript(this.GetType(), "AddWeeknumbers", jscript);
         }
         // Helper function to find ISO week
    private int getISOWeek(DateTime day)
          {
            return System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(day, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
          }
    protected void calendar_OnVisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
           calendar.VisibleDate = e.NewDate;
           addWeekNumberColumn();
        }
    <script type="text/javascript">
            function addWkColumn(tblId, wkStart) {
                var tbl = document.getElementById(tblId);
                var tblBodyObj = tbl.tBodies[0];
                for (var i = 0; i < tblBodyObj.rows.length; i++) {
                    // Month Header
                    if (i == 0) {
                        // Add extra colspan column
                        tblBodyObj.rows[i].cells[0].colSpan = 8;
                    }
                    // Week Header
                    if (i == 1) {
                        // Add week column headline
                        var newCell = tblBodyObj.rows[i].insertCell(0);
                        newCell.innerHTML = 'wk';
                        newCell.style.fontSize = '8px';
                        newCell.style.fontWeight = 'bold';
                        newCell.style.verticalAlign = 'bottom';
                        newCell.style.backgroundColor = '#ffffee';
                    }
                    // Normal row
                    if (i >= 2) {
                        // Add the weeknumbers 
                        var newCell = tblBodyObj.rows[i].insertCell(0);
                        newCell.innerHTML = wkStart;
                        wkStart += 1;
                        if (wkStart == 53) {
                            wkStart = 1;
                        }
                        newCell.style.fontSize = '8px';
                        newCell.style.backgroundColor = '#ffffee';
                    }
                }
            }
        </script>
    <asp:Calendar ID="calendar" runat="server" Font-Names="Tahoma" Font-Size="11px" NextMonthText="&raquo;"
                                                        PrevMonthText="&laquo;" SelectMonthText="&raquo;" SelectWeekText="&rsaquo;" CssClass="myCalendar"
                                                        BorderStyle="None" CellPadding="1" OnSelectionChanged="calendar_SelectionChanged" OnDayRender="calendar_dayrender"
                                                        meta:resourcekey="calendarResource1" FirstDayOfWeek="Monday" OnVisibleMonthChanged="calendar_OnVisibleMonthChanged">
                                                        <DayHeaderStyle CssClass="myCalendarDayHeader" />
                                                        <DayStyle CssClass="myCalendarDay" />
                                                        <NextPrevStyle CssClass="myCalendarNextPrev" />
                                                        <OtherMonthDayStyle ForeColor="Gray" />
                                                        <SelectedDayStyle Font-Bold="True" />
                                                        <SelectorStyle CssClass="myCalendarSelector" />
                                                        <TitleStyle CssClass="myCalendarTitle" />
                                                        <TodayDayStyle ForeColor="Red" Font-Bold="True" />
                                                    </asp:Calendar>
