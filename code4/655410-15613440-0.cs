    protected void btnTryck_Click(object sender, EventArgs e)
    {
        Dagbok bok = DagbokFactory.CreateNew();
    
        bok.Company = String.Format(TextBox1.Text);
        bok.DayNumber = Convert.ToInt32(TextBox19.Text);
        bok.WeatherRain = CheckBox01.Checked;
        bok.Date = DateTime.Now;
    }
