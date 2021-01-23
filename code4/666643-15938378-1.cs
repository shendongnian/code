    Dictionary<string, string> fileDict = new Dictionary<string, string>();
        private void Form1_Load(object sender, EventArgs e)
        {
            fileDict.Add("steam", "C:/steam/steam.exe");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string s = listBox1.SelectedItem.ToString();
                if (fileDict.ContainsKey(s))
                {
                    Process.Start(fileDict[s]);
                }
            }
        }
