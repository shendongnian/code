                    listView1.Items.Clear();
                    int k = 0;
                    foreach (Player p in players)
                    {
                        ListViewItem lvitem = new ListViewItem();
                        lvitem.Text = p.name;
                        lvitem.BackColor = p.color;
                        listView1.Items.Add(lvitem);
                        k++;
                    }
