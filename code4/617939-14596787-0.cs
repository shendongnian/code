    var Months = new List<string>
                {
                       "January",
                       "February",
                       "March",
                       "April",
                       "May",
                       "July",
                       "August",
                       "September",
                       "October",
                       "November",
                       "December"
                };
    private void button1_Click(object sender, EventArgs e)
    {
            if(string.IsNullOrEmpty(labelHiddenCounter.Text))
                labelHiddenCounter.Text = "0";
            if(labelHiddenCounter.Text == "11")
                labelHiddenCounter.Text = "-1";
            var nextCounter = Convert.ToInt32(labelHiddenCounter.Text) + 1;
            label1.Text = (Months[nextCounter]);
            
            labelHiddenCounter.Text = nextCounter.ToString();
    }
