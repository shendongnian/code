        public void AddValues()
        {
            int val1, val2, val3, val4, val5;
            int.TryParse(textBox1.Text, out val1);
            int.TryParse(textBox2.Text, out val2);
            int.TryParse(textBox3.Text, out val3);
            int.TryParse(textBox4.Text, out val4);
            int.TryParse(textBox5.Text, out val5);
            
            textboxtotal.Text = (val1 + val2 + val3 + val4 + val5).ToString();
        }
