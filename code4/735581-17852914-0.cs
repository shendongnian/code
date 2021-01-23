        private void btnAdd_Click(object sender, EventArgs e)
        {
            string _webstring = @"http://";
            string _website = _webstring + textBox1.Text;
            listBox1.Items.Add(_website);
        }
        private void btnLaunch_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", listBox1.SelectedItem.ToString());
        }
