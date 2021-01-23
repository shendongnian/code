    IList<MyObj> myList = new List<MyObj>();
    private void DataBind()
    {
        myListBox.BeginUpdate();
        myListBox.DataSource = myList;
        myListBox.EndUpdate();
    }
    private void OnMyListBoxItemDoubleClicked(object sender, EventArgs e)
    {
        myList.RemoveAt(myListBox.SelectedIndex);
        DataBind();
    }
