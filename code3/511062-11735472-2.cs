            var list = new List<Model>();
            list.Add(new Model { Date = DateTime.Today, Total = 3 });
            list.Add(new Model { Date = DateTime.Today, Total = 3 });
            list.Add(new Model { Date = DateTime.Today, Total = 3 });
            var table = new DataTable();
            table.Columns.Add("Date");
            table.Columns.Add("Total");
            foreach (var grouped in from item in list
                                    group item by new { item.Date, item.Total }
                                        into grouped
                                        select grouped)
            {
                table.Rows.Add(grouped.Key.Date, grouped.Sum(i => i.Total));
            }
