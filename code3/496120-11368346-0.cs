        protected void ddl1OnPanel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblMessageOnPanel1.Text = "From ddl1 " + DateTime.Now.ToString();
            this.calendarOnPanel2.SelectedDate = DateTime.Today.AddDays(1);
            this.lblMessageOnPanel2.Text = "From ddl1 " + DateTime.Now.ToString();
        }
        protected void ddl2OnPanel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblMessageOnPanel1.Text = "From ddl2 " + DateTime.Now.ToString();
            this.calendarOnPanel2.SelectedDate = DateTime.Today.AddDays(2);
            this.lblMessageOnPanel2.Text = "From ddl2 " + DateTime.Now.ToString();
            this.up2.Update();
        }
