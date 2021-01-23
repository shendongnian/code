      var duration_query = this.db.Events
                           .Where(p => ID.Contains(p.ServerID) &&
                           p.Type == "Complete" && 
                          // fromDP and toDP are name of DataPicker control
                           (p.Date >= fromDP.SelectedDate.Value && 
                            p.Date <= toDP.SelectedDate.Value))
                           .GroupBy(p => (((int)(p.Duration / 10)) + 1)*10)
                           .Select(g => new
                           {
                           Duration = g.Key,
                           serverID = g.Count()
                           })
                           .OrderBy(x => x.Duration).ToList();
    
      dgProcessingTime.ItemsSource = duration_query.ToList();
