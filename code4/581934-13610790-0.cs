        private void button1_Click(object sender, EventArgs e)
        {
            List<string> strlst;
            StringBuilder sb = new StringBuilder();
            foreach(string s in strlst)
            {
                sb.AppendLine(s);
            }
            MessageBox.Show(sb.ToString());
        }
