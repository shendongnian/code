        protected void Page_Load(object sender, EventArgs e)
        {
            ShowContactAlternate();
        }
        private void ShowContactAlternate()
        {
            if ((int)DateTime.Now.DayOfWeek % 2 == 0)
                primaryContact.Visible = true;
            else
                secondaryContact.Visible = true;
        }
