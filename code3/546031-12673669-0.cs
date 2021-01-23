    var plst = ...
    
    var persons = from GridViewRow r in gv_contactList.Rows
                  select new Person {
                    Id = int.Parse(gv_contactList.DataKeys[r.RowIndex].Value.ToString()),
                    Name = r.Cells[1].Text.TrimEnd(),
                    Mobile = r.Cells[2].Text.TrimEnd(),
                    Email = r.Cells[3].Text.TrimEnd(),
                    Pkind = 1,
                  };
                
    var mobiles = persons.Aggregate(new List<string>(), (acc, cur) => 
                  {
                    plst.Add(cur);
                    if (!string.IsNullOrEmpty(cur.Mobile))
                        acc.Add(cur.Mobile);
                    return acc;
                  }).ToArray();
