    DataTable _dt = new DataTable();
    foreach (SPField spf in _lst.Fields)
    {
       _dt.Columns.Add(spf.InternalName.ToString(), spf.Type.GetType());
    }
