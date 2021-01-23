    private void button6_Click(object sender, EventArgs e)
    {
        string[] entries = File.ReadAllLines(@"D:\Keywords.txt"));
        foreach (string entry in entries)
        {
            string[] values = entry.Split(',');
            LocalyKeyWords[values[0]].Clear();
            for (int i = 1; i < values.Length; i++)
                LocalyKeyWords[values[0]].Add(values[i]); 
        }
        using (var w = new StreamWriter(@"D:\Keywords.txt"))
        {
            crawlLocaly1 = new CrawlLocaly();
            crawlLocaly1.StartPosition = FormStartPosition.CenterParent;
            DialogResult dr = crawlLocaly1.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                if (LocalyKeyWords.ContainsKey(mainUrl))
                {
                    LocalyKeyWords[mainUrl].Clear(); //probably you could skip this part and create new List everytime
                    LocalyKeyWords[mainUrl].Add(crawlLocaly1.getText());
                }
                else
                {
                    LocalyKeyWords[mainUrl] = new List<string>();
                    LocalyKeyWords[mainUrl].Add(crawlLocaly1.getText());
                }
                foreach (KeyValuePair<string, List<string>> kvp in LocalyKeyWords)
                {
                    w.WriteLine(kvp.Key + "," + string.Join(",", kvp.Value));
                }
            }
        }
    }
