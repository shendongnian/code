            String arrival, departure;
            arrival = textBox1.Text;
            departure = textBox2.Text;
            DateTime aDate, dDate;
            
            try
            {
                aDate = DateTime.ParseExact(arrival, "dd/mm/yyyy", null);
                dDate = DateTime.ParseExact(departure, "dd/mm/yyyy", null);
                TimeSpan dateDiff;
                dateDiff = dDate.Subtract(aDate);
                int nights = (int)dateDiff.TotalDays;
                textBox3.Text = ("" + nights);
                textBox5.Text = ("£" + (nights * 115));
            }
            catch
            {
                MessageBox.Show("Invalid input format please enter in format DD/MM/YYYY");
            }
