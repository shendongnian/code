    protected void Button1_Click(object sender, EventArgs e)
    {
            string a, b;
            a = TextBox1.Text.ToString().Trim();
            b = TextBox2.Text.ToString().Trim();
            DateTime c = new DateTime();
            DateTime d = new DateTime();
            c = Convert.ToDateTime(a);
            d = Convert.ToDateTime(b);
    
            DateTime to_datetime = DateTime.ParseExact(a, "dd/MM/yyyy",
                                               System.Globalization.CultureInfo.InvariantCulture);
            DateTime from_datetime = DateTime.ParseExact(b, "dd/MM/yyyy",
                                                         System.Globalization.CultureInfo.InvariantCulture);
            System.TimeSpan diffr = to_datetime - from_datetime;
            Response.Write(diffr.Days);
    }
