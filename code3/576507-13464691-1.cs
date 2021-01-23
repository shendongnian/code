    using (var usedRange = sheet.UsedRange.WithComCleanup())
    {
        string firstAddress = string.Empty;
        string nextAddress = string.Empty;
        using (var firstCell = usedRange.Resource.Find("Changes for Version", LookIn: XlFindLookIn.xlValues).WithComCleanup())
        {    
            if (firstCell.Resource != null)
            {
                firstAddress = firstCell.Resource.Address;
                AppendListOfVersion(sheet.Name, firstCell.Resource);
                nextAddress = firstAddress;
            }
        }
    }
    if (firstAddress != "") // the first Find attempt was successful, so keep looking (FindNext)
    {
        var keepLooking = true;
        while (keepLooking)
        {
            using (var prevCellToFindNextFrom = sheet.Range[nextAddress].WithComCleanup())
            using (var nextCell = usedRange.Resource.FindNext(prevCellToFindNextFrom.Resource).WithComCleanup())
            {
                if (nextCell.Resource == null)
                    keepLooking = false;
                else
                {
                    nextAddress = nextCell.Resource.Address;
                    if (nextAddress == firstAddress)
                        keepLooking = false;
                    else
                        AppendListOfVersion(sheet.Name, nextCell.Resource);
                }
            }
        }
    }
