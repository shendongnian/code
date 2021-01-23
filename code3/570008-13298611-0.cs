    var LookUpEvents = from d in ThisData.Events.Local
                       where d.StartDate.Value.Date <= DateTime.Now.Date &&
                       (d.EndDate.HasValue == false || d.EndDate.Value.Date >= DateTime.Now.Date)
                       select d;
    
    // Old binding: RangeEventGrid.ItemsSource = LookUpEvents;
    // New binding:
    RangeEventGrid.ItemsSource = LookUpEvents.ToList(); // .ToList() Fixes it!
    RangeEventGrid.Items.Refresh();
