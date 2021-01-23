        private void button1_Click(object sender, EventArgs e)
        {
            const int value = 100;
            int previousValue;
            if (!int.TryParse(totalMoneyLabel.Value, NumberStyles.Integer, new CultureInfo("en-Us"), out previousValue))
                previousValue = 0;
            var rand = new Random();
            var roll1 = rand.Next(6) + 1;
            var sum = previousValue+(roll1 * value);
            totalMoneyLabel.Text = sum.ToString("c", new CultureInfo("en-Us"));
        ....
        }
