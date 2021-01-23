    List<string> list = {
                           "8/1/2013 9:57:52 PM|Login for bill.lock@cap.com",
                           "8/1/2013 9:57:37 PM|Login for bill.lock@cap.com"
                        };
    var a = dt.AsEnumerable().Where(x=>
                  list.Select(y=> new {
                                        Time =  DateTime.Parse(y.Split('|')[0]),
                                        Text = y.Split('|')[1]
                                      })
                      .Any(z=> z.Time == x.Time && z.Text == x.Text));
    DataTable newTable = a.CopyToDataTable();
