    for (int col = 0; col < GridData.Columns.Count; col++)
                {
                    double a;
                    double avg = GridData.AsEnumerable()
                        .Where(x => x[col] != DBNull.Value && double.TryParse(x[col].ToString(), out a))
                        .Average(x => double.Parse(x[col].ToString()));
                    mylist.Add(avg);
                }
