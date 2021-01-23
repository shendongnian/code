        private void button1_Click(object sender, EventArgs e)
        {
            int previousValue;
            if (!int.TryParse(totalMoneyLabel.Text.Substring(1), out previousValue))
                previousValue = 0;
            const int value = 100;
            var rand = new Random();
            var roll1 = rand.Next(6) + 1;
            var sum = previousValue+(roll1 * value);
            totalMoneyLabel.Text = sum.ToString("c");
        ....
        }
