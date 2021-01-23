    @{
     List<string> shortDates = new List<string>();
     for (var i = 0; i < Model.Dates.Count; i++)
     {
      shortDates.Add(Model.Dates.ElementAt(i).ToShortDateString());
      }
    }
