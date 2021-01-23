    allcont ac = new allcont();
    ac.name = m.Groups[1].Value;
    ac.number = m.Groups[2].Value;
    con.Add(ac);
    foreach (allcont aa in con)
    {
         ListViewItem i = new ListViewItem(new string[] { aa.name, aa.number });
         i.Tag = aa;
         listView1.Items.Add(i);
     }
