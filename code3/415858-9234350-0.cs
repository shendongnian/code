        private void timer1_Tick(object sender, EventArgs e)
        {
            Application.DoEvents();
            Thread.Sleep(200);
            start++;
            string str = join.Substring(start, 15);
            byte[] bytes = Encoding.BigEndianUnicode.GetBytes(str);
            label9.Text = str;
            if (start == number - 15)
            {
                start = 0;
            }
        }
