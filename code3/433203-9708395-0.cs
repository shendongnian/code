    destinationList.ForEach(d => {
                                   var si = sourceList
                                               .Where(s => s.Id == d.Id)
                                               .FirstOrDefault();
                                   d.Name = si != null ? si.Name : "";
                                 });
    destinationList.RemoveAll(d => string.IsNullOrEmpty(d.Name));
