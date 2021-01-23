        private void textBox1_KeyUp(object sender, KeyEventArgs e)        
        {
            if (e.KeyCode == Keys.Enter)
            {
                string s = textBox1.Text;
                if (s.Contains('.'))
                {
                    string[] arr = s.Split('.');
                    decimal dec = decimal.Parse(arr[0]);
                    textBox1.Text = string.Format("{0},{1}", dec.ToString("## ###"), arr[1]);
                }
            }
        }
