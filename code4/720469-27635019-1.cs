    private void button1_Click(object sender, EventArgs e)
    {
         string inputString = textBox1.Text;
         DateTime dt = DateTime.ParseExact(inputString, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
         dt = dt.Date.AddMonths(6);
         textBox2.Text = dt.ToString("yyyyMMdd");
    }
