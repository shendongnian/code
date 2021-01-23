    dWConnection.Open();
    dWDataAdaptor.SelectCommand = dWCommand1;
    dWDataAdaptor.Fill(queryResults1);
    dWDataAdaptor.SelectCommand = dWCommand2;
    dWDataAdaptor.Fill(queryResults2);
    dWConnection.Close();
                
    IEnumerable<DataRow> results1 = (from events in queryResults1.AsEnumerable()
                           where events.Field<string>("event_code").ToString() == "A01"
                           ||  events.Field<string>("event_code").ToString() == "ST"
                           select events ) as IEnumerable<DataRow>;
    var results2 = from events1 in queryResults1.AsEnumerable()
        join events2 in queryResults2.AsEnumerable()
        on (string)events1["event_code"] equals (string)events2["event_code"]
        select new
                {
                      f1 = (string)events1["event_code"],
                      f2 = (string)events2["event_name"]
                };
    DataTable newDataTable = new DataTable();
    newDataTable = results1.CopyToDataTable<DataRow>();
