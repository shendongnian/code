         private void btnAdd_Click(object sender, EventArgs e)
        {
            string _webstring = @"http://";
            string _website = _webstring + textBox1.Text;
            listBox1.Items.Add(_website);
            using (StreamWriter w = File.AppendText("websites.txt"))
            {
                    WriteLog(_website, w);
            }
            using (StreamReader r = File.OpenText("websites.txt"))
            {
                DisposeLog(r);
            }
        }
        private void btnLaunch_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", listBox1.SelectedItem.ToString());
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter w = File.AppendText("websites.txt"))
            {
                foreach (string items in listBox1.Items)
                {
                    WriteLog(items, w);
                }
            }
            using (StreamReader r = File.OpenText("websites.txt"))
            {
                DisposeLog(r);
            }
        }
        public static void WriteLog(string logMessage, TextWriter w)
        {
            w.WriteLine(logMessage, logMessage);
        }
        public static void DisposeLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            using (TextReader txtRead = File.OpenText("Websites.txt"))
            {
                string _text = "";
                string[] _textArray = null;
                while ((_text = txtRead.ReadLine()) != null)
                {
                    _textArray = _text.Split('\t');
                    listBox1.Items.Add(txtRead.ReadLine());
                }
                txtRead.Close();
            }
        }
