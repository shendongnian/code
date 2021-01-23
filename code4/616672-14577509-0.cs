     protected void Page_Load(object sender, EventArgs e)
        {
            decimal[] usstat = new decimal[] { 10, 15, 16, 18, 20 };
            decimal[] ukstat = new decimal[] { 14, 18, 6, 11, 32 };
         
            if (BarChart1.Series[0].Name == "US")
            {
                BarChart1.Series[0].BarColor = "#6C1E83";
                BarChart1.Series[0].Data = usstat;
            }
            if (BarChart1.Series[1].Name == "UK")
            {
                BarChart1.Series[1].BarColor = "#D08AD9";
                BarChart1.Series[1].Data = ukstat;
            }
