    public void Update<T, U>(T _t, T team, Func<T, IList<U>> selector) 
    {
        var _tItems = selector(_t);
        var teamItems = selector(team);
        // Archive deleted MyItems sections
        _tItems.Where(x => x.ValidTo == null && !teamItems.Contains(x)).ToList().ForEach(x => x.ValidTo = DateTime.Now);
        // Add or update MyItems sections
        foreach (var MyItemsSection in teamItems)
        {
            if (MyItemsSection.Id == default(int))
            {
                MyItemsSection.ValidFrom = DateTime.Now;
                _tItems.Add(MyItemsSection);
            }
            else
            {
                var _MyItemsSection = _tItems.FirstOrDefault(x => x.Id == MyItemsSection.Id);
                context.Entry(_MyItemsSection).CurrentValues.SetValues(MyItemsSection);
            }
        }
    }
    
        //Usage:
        Update(_t, team, (t => t.MyItems));
