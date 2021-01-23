        delegate void SetListViewItemCallBack(ListViewItem Item);
        private void AddListViewItem(ListViewItem Item)
        {
            if (this.listView1.InvokeRequired)
            {
                SetListViewItemCallBack d = new SetListViewItemCallBack(AddListViewItem);
                this.Invoke(d, new object[] { Item });
            }
            else
            {
                this.listView1.Items.Add(Item);
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DataSet dsInfo = // whatever you want..
            for (int i = 0; i < dsInfo.Tables[0].Rows.Count; i++)
            {
                ListViewItem li = new ListViewItem();
                li.Text = dsInfo.Tables[0].Rows[i]["AXT_Tag"].ToString();
                li.Tag = dsInfo.Tables[0].Rows[i]["AXT_ID"].ToString();
                AddListViewItem(li);
            }
        }
