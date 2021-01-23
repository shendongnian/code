    log.CommandText = String.Format("SELECT * from log order by date desc limit {0}", lognr);  //the output has 3 columns and several rows.
    Reader = log.ExecuteReader();
    int i = 0;
    while (Reader.Read())
    {
    logs = logs + "\r\n" + Reader.GetValue(0).ToString() + " " + Reader.GetValue(1).ToString() + " "+ " " + Reader.GetValue(2).ToString();
    i++;
    }
