    con.Add(ac);
                    foreach (allcont aa in con)
                    {
                        ListViewItem i = new ListViewItem(new string[] { aa.name, aa.number });
                        i.Tag = aa;
                        listView1.Items.Add(i);
                    }
