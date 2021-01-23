     private void UpdateThreadListView(int threadNumber, string proxy, string query, string page, string links)
        {
            int index = threadNumber;
            Invoke(new MethodInvoker(
                           delegate
                           {
                               listView1.BeginUpdate();
    
                               ListViewItem itm = listView1.Items[index];
    etc..
