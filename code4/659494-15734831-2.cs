    List<double> mylist = new List<double>();
    for (int col = 0; col < GridData.Columns.Count; col++)
    {
           double a;
           double avg = GridData.AsEnumerable()
                 .Where(x => x[col] != DBNull.Value)
                 .Average(x => double.TryParse(x[col].ToString(), out a) ? a:0.0);
                       mylist.Add(avg);
    }
