     protected void Page_Load(object sender, EventArgs e)
            {
                           
                DateTime date = DateTime.Now;    // display format: 4/25/2008 11:45:44 AM
                int mon = date.Month;
                if (mon < 6)
                {
                    datelabel.Text = "Jan-june" +date.Year;
                }
                else
                    datelabel.Text = "july-dec" +date.Year;
        
            }
