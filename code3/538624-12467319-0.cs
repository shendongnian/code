        public void WriteLog(string sText)
        {
            _sync.Send((state) => {
               MessageBox.Show(sText);
               listBox1.Items.Add(sText);
            }, null);
        }
