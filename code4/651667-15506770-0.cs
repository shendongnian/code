    public void UpdateTable(int idRecord, YourContext Context)
    { 
        MyRecord = Context.MyTable.Find(idRecord);
        myRecord.Column = "New Value";
        Context.SaveChanges();
     }
