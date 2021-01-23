    protected void Button1_Click(object sender, EventArgs e)
    {
        Site1 site = this.Master as Site1;
        if (site != null)
        {
            Label SensorTemperatureLabel = site.FindControl("SensorTemperatureLabel") as Label;
            SensorTemperatureLabel.Text = DateTime.Now.ToString();
        }
    }
