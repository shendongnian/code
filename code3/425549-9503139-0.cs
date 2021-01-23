    var formentries = from f in db.bNetFormEntries
                    join s in db.bNetFormStatus on f.StatusID.Value equals s.StatusID into entryStatus
                    join s2 in db.bNetFormStatus on f.ExternalStatusID.Value equals s2.StatusID into entryStatus2
                    where f.FormID == formID
                    orderby f.FormEntryID descending
                    select new FormEntry
                    {
                        FormEntryID = f.FormEntryID,
                        FormID = f.FormID,
                        IPAddress = f.IpAddress,
                        UserAgent = f.UserAgent,
                        CreatedBy = f.CreatedBy,
                        CreatedDate = f.CreatedDate,
                        UpdatedBy = f.UpdatedBy,
                        UpdatedDate = f.UpdatedDate,
                        StatusID = f.StatusID,
                        StatusText = entryStatus.FirstOrDefault().Status,
                        ExternalStatusID = f.ExternalStatusID,
                        ExternalStatusText = entryStatus2.FirstOrDefault().Status
                    };
    
    var formEntryDictionary = new Dictionary<int, FormEntry>();
    
    foreach (formEntry in formentries)
    {
        formentry.Values = GetValuesForFormEntry(formentry, entryvalues); //implement this :)
        formEntryDict.Add(formEntry.FormEntryID, formEntry);
    }
    
    return formEntryDictionary;
