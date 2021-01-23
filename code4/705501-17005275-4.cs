    List<string> lst = new List<string>();
                lst.AddRange(new string[] { "one", "two", "three", "four" });
                int column = 1 ;//this could be some input like int.Parse(TextBox1.text)
                int row = 0;
                foreach (var value in lst)
                {
                    if (!(column >= listView1.Columns.Count))//check to see if its not above column collection
                    {
                        ListViewItem item = new ListViewItem();
                        listView1.Items.Add(item);
                        ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
                        lvsi.Text = value.ToString();
                        listView1.Items[row].SubItems.Insert(column, lvsi);
                        row++;
                    }
    
                }
