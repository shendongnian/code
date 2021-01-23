    ListViewItem _listViewItem;
    
    private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
    {
        //your loop to get list view item
        _listViewItem = new ListViewItem(mytext) {tag = mytagobject);
        _listViewItem.SubItems.Add(mysubitemtext);
        Invoke(new EventHandler(UpdateUiEvent), new[] { sender, e });
    }
    
    void UpdateUiEvent(object sender, EventArgs e)
    {
        listView1.Items.Add(_listViewItem);
    }
