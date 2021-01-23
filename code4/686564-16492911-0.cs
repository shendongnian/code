    public Record GetRecord(int RecordId, DateTime Date)
    {
      var r = records.firstOrDefault(record => record.Id == RecordId && record.Date < Date)
      
      if(r != null && r.ParentId != null)
        return GetRecord(r.ParentId, Date)  // Get the parent, if existing..
      else
        return r;                           // Return the matching record
    }
