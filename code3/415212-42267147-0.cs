    List<CheckItems>  vendlist = new List<CheckItems>();
    var vnlist =    from up in spcall
                    where up.Caption == "Contacted"
                    select new
                      {
                          up.Caption,
                          up.TargetDate,
                          up.ActualDate,
                          up.Value
                      };
    foreach (var item in vnlist)
                {
                    CheckItems temp = new CheckItems();
                    temp.Description = item.Caption;
                    temp.TargetDate = string.Format("{0:MM/dd/yyyy}", item.TargetDate);
                    temp.ActualDate = string.Format("{0:MM/dd/yyyy}", item.ActualDate);
                    temp.Value = item.Value;
                    vendlist.Add(temp);
                }
