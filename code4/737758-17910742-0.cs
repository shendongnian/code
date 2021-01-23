        private void timer1_Tick(object sender, EventArgs e) {
            textBox1.Text = initialVal.ToString();
            int sum = calculation(initialVal);
            textBox2.Text = sum.ToString();
            if (initialVal++ == 20)
                timer1.Enabled = false; 
        }
