    protected void FillRecordOrder(object rec, object[] fields)
    {
        OrdersVerticalBar record = (OrdersVerticalBar) rec;
    
        if (fields[0] == null)
          record.OrderDate = DateTime.MinValue;
        else if (fields[0] is DateTime)
          record.OrderDate = (DateTime)fields[0];
        else if (fields[0] is int)
        {
          DateTime baseDate = new DateTime(1900, 1, 1);
          DateTime newDate = baseDate.AddDays((int)fields[0]);
          record.OrderDate = newDate;
        }
    }
