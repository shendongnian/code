    var groupedNotes = ungroupedNotes.GroupBy(x => new { x.Date, x.Time })
                                     .Select(x => new Note
                                                  {
                                                      Date = x.Key.Date,
                                                      Time = x.Key.Time,
                                                      Text = string.Join(
                                                               ", ",
                                                               x.Select(y => y.Text))
                                                  })
                                     .ToList();
