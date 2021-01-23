    private static IEnumerable<Tuple<T, T>> ListPairs<T>(IEnumerable<T> source)
    {
       using (var enumerator = source.GetEnumerator())
       {
           if (!enumerator.MoveNext()) yield break;
           
           T previous = enumerator.Current;
           while (enumerator.MoveNext())
           {
              T current = enumerator.Current;
              yield return new Tuple<T, T>(previous, current);
              previous = current;
           }
       }
    }
    
    public ObservableCollection<Appointment> FillGaps()
    {
       var gaps = ListPairs(this.Appointments.OrderByDescending(s => s.EndDate))
          .Where(pair => (pair.Item1.StartDate.Value - pair.Item2.EndDate.Value).Days > 1)
          .Select(pair => new Appointment
          {
             StartDate = pair.Item2.EndDate.Value.AddDays(1),
             EndDate = pair.Item1.StartDate.Value.AddDays(-1),
             IsCurrent = false,
          });
       
       // NB: Assumes "this.Appointments" is a cheap call;
       // Also assumes you don't need the results in any particular order.
       return this.Appointments.Concat(gaps).ToObservableCollection();
    }
