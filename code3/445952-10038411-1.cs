    using (var logClass = new LoggingDisposeable())
    {
        var options = new ParallelOptions();
        options.MaxDegreeOfParallelism = 5;
        Parallel.ForEach(urlTable.AsEnumerable(), options, drow =>
            {
                logClass.GenericLogging("ZipCode not available for this dealerL", "DealershipRequest", "checkExistingDealers", dealerID, "DealerShipZipCode", rDealerLink, "", "");
            });
    }
