    public void SimpleSearch()
    {
      DataClasses1DataContext dc = new DataClasses1DataContext();
      var search = txtSearch.Text.ToLower();
    var q =
        from a in dc.GetTable<Books>()
        where a.Title.ToLower() == search ||
        a.Author.ToLower() == search ||
        a.Author.ToLower().Contains(search) ||
        a.Title.ToLower().Contains(search)
        select a;
    dataGridView1.DataSource = q;
    }
