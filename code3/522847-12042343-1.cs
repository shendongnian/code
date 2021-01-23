    var result = from thing in search
                 let names = thing.Subthings
                                  .Where(sub => sub.Prop1 == 1 && sub.Prop2 != null)
                                  .Select(sub => sub.Name)
                 where names.Any()
                 select new { ID = thing.ID, Names = names };
