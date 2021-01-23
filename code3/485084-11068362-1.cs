        protected DateTime getFirstWednesdayOfMonth(DateTime seedDate)
        {
            DateTime wed1 = new DateTime(seedDate.Year, seedDate.Month, 1); //1st Wednesday can start on the 1st of the month
            while (wed1.DayOfWeek != DayOfWeek.Wednesday)
            {
                wed1 = wed1.AddDays(1);
            }
            return wed1;
        }
        protected DateTime getThirdWednesdayOfMonth(DateTime seedDate)
        {
            DateTime wed3 = new DateTime(seedDate.Year, seedDate.Month, 15); //3rd Wednesday cannot start prior to the 15th of the month
            while (wed3.DayOfWeek != DayOfWeek.Wednesday)
            {
                wed3 = wed3.AddDays(1);
            }
            return wed3;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime Now = DateTime.Today;
            DateTime wed1 = getFirstWednesdayOfMonth(Now);
            DateTime wed3 = getThirdWednesdayOfMonth(Now);
            if (Now < wed1)
            {
                lblDate.Text = wed1.ToString();
            }
            else if (Now < wed3)
            {
                lblDate.Text = wed3.ToString();
            }
        }
