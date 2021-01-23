    public void SimpleSearch()
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
    
        var q =
            from a in dc.GetTable<Books>()
            where a.Title == "1984" || a.Author == "Stephen King" || a.Price == 5.99m
            select a;
        dataGridView1.DataSource = q;
    }
