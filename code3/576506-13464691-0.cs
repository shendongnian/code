    using (var usedRange = sheet.UsedRange.WithComCleanup())
    {
        string firstAddress = string.Empty;
        string nextAddress = string.Empty;
        using (var firstCell = usedRange.Resource.Find("Changes for Version", LookIn: XlFindLookIn.xlValues).WithComCleanup())
        {
    
            if (firstCell.Resource != null)
            {
                firstAddress = firstCell.Resource.Address;
                value = firstCell.Resource.Value2;
            }
        }
    }
