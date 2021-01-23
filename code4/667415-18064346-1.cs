    public void UpdatingListView(string[] array)
        {
            if (this.listView.InvokeRequired)
            {
                this.listView.Invoke(new MyDelegate(UpdatingListView), new object[] { array });
            } else {
                ListViewItem lvi = new ListViewItem(array[0]);
                lvi.SubItems.Add(array[1]);
                lvi.SubItems.Add(array[2]);
                this.listView.Items.Add(lvi);
            }
        }
