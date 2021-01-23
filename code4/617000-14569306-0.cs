    IEnumerable<Results> subResult = from query in datatable.AsEnumerable()
                                  select new Results
                                  {
                                      Name = query.Field<string>("Name")?? string.Empty,
                                      Date = query.Field<DateTime?>("Date")
                                  }
