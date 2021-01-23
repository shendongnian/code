    var members = from s in myEntites.TableName
                  select s;
                foreach (TableEntry entry in members)
                {
                    String time = ((DateTime)entry.date).ToString("HH:mm:ss.fff");
                    Console.WriteLine(time);
                }
