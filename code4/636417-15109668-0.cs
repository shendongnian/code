    string list = item.Soid+ "|" +
                  item.Soid + "|" +
                  item.ProjectTitle + "|" +
                  item.Role + "|" +
                  item.StartDate.ToShortDateString() + "|" +
                  item.EndDate.value.ToShortDateString() + "|" +
                  item.Location.Country + "|" +
                  item.Location.State + "|" +
                  item.Location.City + "|" +
                  item.Achievements.Any() + "|" + // <--- Here is a solution
                  item.Achievements.Count() + "|" +
                  item.Soid + "|" +
                  item.Soid + "|" +
                  item.Soid + "|" +
                  item.Soid + "|" +
                  projectlist.Add(list);
