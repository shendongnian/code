    List<int> personIDs = 
         messages.SelectMany(m => m.PostedToPersonID.HasValue ?
                      new int[] { m.PostedToPersonID.Value, m.CreatedByPersonID } :
                      new int[] { m.CreatedByPersonID })
                 .Distinct()
                 .ToList();
