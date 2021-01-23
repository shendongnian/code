    var query = from foo in db.Bar
                let bar = db.MyTables.FirstOrDefault(x => x.MyID == idToFind).DateValue
                select  new 
                {
                   MyDate = bar == DateTime.MinValue ? DateTime.Now : bar
                }
