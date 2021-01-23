       private void timer1_Tick(object sender, EventArgs e)
        {
            bufferedListView1.Items.Clear();
            StreamReader sr = new StreamReader("C:\\sample.txt");
            contacts con = new contacts();
            string s;
            s = sr.ReadLine();
            while (s != null)
            {
                s = sr.ReadLine();
                var m = Regex.Match(s, @"^([a-zA-Z._]+)@([\d]+)");
                if (m.Success)
                {
                    allcont ac = new allcont();
                    ac.name = m.Groups[1].Value;
                    ac.number = m.Groups[2].Value;
                    con.Add(ac);
                    s = sr.ReadLine();
                }
            }
            foreach (allcont aa in con)
            {
                ListViewItem i = new ListViewItem(new string[] { aa.name, aa.number });
                i.Tag = aa;
                bufferedListView1.Items.Add(i);
            }
            sr.Close();
    
        }
    
        public class contacts:List<allcont>
        { 
    
        }
        public class allcont
        {
            public string name;
            public string number;
        }
