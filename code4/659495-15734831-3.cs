    List<double> mylist = new List<double>();
    for (int col = 5; col < GridData.Columns.Count; col++)
    {
           double avg = GridData.AsEnumerable()
                .Where(x => x[col] != DBNull.Value)
                .Average(x => double.Parse(x[col].ToString()));
                    mylist.Add(avg);
    }
