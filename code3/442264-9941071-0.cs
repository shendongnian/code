    public List<string> Select(string mQuery)
    {
        //...
    }
    List<string> list = mDB.Select(mQuery);
    MessageBox.Show(string.Join(",", list));
