    void Button1Click(object sender, EventArgs e)
    {
        removeItems();
    }
    private void timer_Tick(object sender, System.Timers.ElapsedEventArgs e)
    {
        removeItems();      
    }
    void removeItems()
    {
        MessageBox.Show("Hello from the removeMethod");
        RemoveListViewItem(0);
    }
    public delegate void InvokeRemoveListViewItem(Int32 ItemIndex);
    public void RemoveListViewItem(Int32 ItemIndex)
    {
        if (InvokeRequired)
        {
            try { Invoke(new InvokeRemoveListViewItem(RemoveListViewItem), new Object[] { ItemIndex }); }
            catch (Exception)
            {
                //react to the exception you've caught
            }
        }
        listView.RemoveAt(ItemIndex);
    }
