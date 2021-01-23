    DataTable dt = new DataTable(String.Format("{0}For{1}", gv.ID.Substring(2, gv.ID.Length - 2), year));
    DataColumn idCol = new DataColumn("ID");
    DataColumn nameCol = new DataColumn("Name");
    //etc.
    dt.Columns.Add(idCol);
    dt.Columns.Add(nameCol);
    //etc.
