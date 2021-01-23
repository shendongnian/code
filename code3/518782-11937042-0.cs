    partial void UpdateTable1(Table1 instance)
    {
        //update some fields
        this.ExecuteDynamicUpdate(instance);
    
        DataContext db = new DataContext();
        db.Table2s.InsertOnSubmit(instance.ConvertToTable2());
        db.SubmitChanges();
    }
