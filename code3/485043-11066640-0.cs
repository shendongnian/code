    private void listView1_MouseClick(object sender, MouseEventArgs e)
            {
                ListView listView = sender as ListView;
                this.contextMenuStrip1.Items.Clear();
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    ListViewItem item = listView.GetItemAt(e.X, e.Y);
                    this.contextMenuStrip1.Items.Add(item.Text);
                    if (item != null)
                    {
                        item.Selected = true;
                        contextMenuStrip1.Show(listView, e.Location);
                    }
                }
            }
