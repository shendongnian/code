            TextReader r = new StreamReader(@"d:\test.txt");
            string line = string.Empty;
            while ((line = r.ReadLine()) != null)
            {
                string[] data = line.Split(new char[] { ' ' },  StringSplitOptions.RemoveEmptyEntries);
                ListViewItem lvi = new ListViewItem("url: " + data[1] + " " + data[2]);
                listView1.Items.Add(lvi);
            }
 
