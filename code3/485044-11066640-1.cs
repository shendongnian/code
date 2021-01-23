       private void listView1_MouseClick(object sender, MouseEventArgs e)
                {
                    ListView listView = sender as ListView;
                    this.contextMenuStrip1.Items.Clear();
                    if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        ListViewItem item = listView.GetItemAt(e.X, e.Y);
                        if (item != null)
                        {
                            this.contextMenuStrip1.Items.Add(item.Text);
                            item.Selected = true;
                            contextMenuStrip1.Show(listView, e.Location);
                        }
                    }
                }
