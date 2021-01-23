        minimumDateTime = DateTime.Min; // don't force to first record.. let loop do it
        var minDates = new List<DateTime>();
        foreach (Node rb in lf.Nodes)
        {
            TimeSpan intervalMinutes = rb.InitiationDate.Subtract(minimumDateTime);
            UserConfirmationErrors confirmationRun = new UserConfirmationErrors();
            if (intervalMinutes.TotalMinutes >= 30)
            {
                //New Minimum Date/Time
                minimumDateTime = rb.InitiationDate;
                minDates.Add(minimumDateTime); // add to new collection
            }
        }
    // now loop your minDates to create your select list
    var items = new List<SelectListItem>();
    foreach(var minDate in minDates)
    {
      var item = new SelectListItem() { Value = minDate.ToString(), Text = String.Format("{0} - {1}", minDate, minDate.AddMinutes(30) };
    
      items.add(items);
    }
    
    // now items is your collection that you can bind your select list to...
