    using(MyEntities e = new MyEntities)
    {
        var Rows = e.MyTable.Where(x => x.UsageRamID > 10 &&  x.UsageRamID < 20);
        
        foreach(var Row in Rows)
            MessageBox.Show("Available=" + Row.Available.ToString() + ",Used=" + Row.Used.ToString();
    }
