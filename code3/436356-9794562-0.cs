        private void loadMatchingResponsesReports()
        {
            listBox2.Items.Clear();
            string[] list = getMatchingReports();
            foreach (String S in list)
            {
                FileInfo fileResponse = new FileInfo(S);
                string fileResponseNameOnly = fileResponse.Name;
                listBox2.Items.Add(fileResponseNameOnly);
                GC.Collect();
            }
        }
        public string[] getMatchingReports()
        {
            string[] returnR = null;
            try
            {
                returnR = Directory.GetFiles(textBox3.Text + @"\", "*.xls");
            }
            catch
            {
                MessageBox.Show("Can't get some files from directory " + textBox3.Text);
            }
            return returnR;
        }
