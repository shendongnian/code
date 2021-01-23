    for (int kk = 1; kk <= totQsn; kk++)//using this I am adding items to listview
            {
                lvi = new ListViewItem();
                lvi.Selected = false;
                lvi.Text = kk.ToString();
                listView1.Items.Add(lvi);                
            }    
    listView1.Items[0].Selected = true;
