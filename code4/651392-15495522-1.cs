    using(MyEntities e = new MyEntities)
    {
        var Row = e.MyTable.First(x => x.UsageRamID = **[ID]**);
        
        MessageBox.Show("Available=" + Row.Available.ToString() + ",Used=" + Row.Used.ToString();
    }
