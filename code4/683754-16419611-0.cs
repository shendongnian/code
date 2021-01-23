        void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ListViewItem last = null;
            if (this.listView1.Items.Count > 0)
            {
                last = this.listView1.Items[listView1.Items.Count - 1];
            }
            if (last == null || last.Text != CurrentTrack.Name)
            {
                ListViewItem LVI = new ListViewItem(currentTrack.Name);
                LVI.SubItems.Add(keywords);
                LVI.SubItems.Add("Updated");
                listView1.Items.Add(LVI);
                listView1.TopItem = LVI;
                listView1.EnsureVisible(listView1.Items.Count - 1);
            }
            progressBar1.Value = e.ProgressPercentage;
            lblStatus.Text = "Processing......" + progressBar1.Value.ToString() + "%";
        }
