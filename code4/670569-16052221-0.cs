    var tpcs = new List<string>();
    var filtered = records.GroupBy(record =>
    {
      //Keep a track of the available TPC types
      if (!tpcs.Contains(record.TPC))
      {
        tpcs.Add(record.TPC);
      }
      return record.DCID;
    })
    .Where(group =>
    {
      //Get the TPCs for the group
      var groupTpcs = group.Select(record => record.TPC);
      //Only return groups that have records for all the TPC types
      return groupTpcs.Intersect(tpcs).Count() == tpcs.Count;       
    });
    //Print groups
    foreach (var group in filtered)
    {
      Console.WriteLine(group.Key);
      foreach (var record in group)
      {
        Console.WriteLine("\tID = {0}, TPC = {1}, DCID = {2}", record.ID, record.TPC, record.DCID);
      }
    }
