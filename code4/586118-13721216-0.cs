     protected void Calendar1_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
                {
                DateTime dt = new DateTime();
                dt=Calendar1.SelectedDate;
                string date;
                date = dt.Year.ToString() + "/" + dt.Month.ToString() + "/" + dt.Day.ToString();
                txtpickupdate.Text = date;
                Calendar1.Visible = false;
               }
        }
