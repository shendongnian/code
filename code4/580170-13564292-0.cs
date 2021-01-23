    private static IEnumerable<LedgerSummary> FilterLedgersImpl(IEnumerable<LedgerSummary> ledgers, Func<LedgerSummary, LedgerAccount, bool> predicate)
    {
        var excludedLedgerEntries = 
            ledgers
               .Where(x => excludedLedgerAccounts.Any(y => predicate(x, y)))
               .ToList();
    
        var filteredLedgers = ledgers.Except(excludedLedgerEntries).ToList();
    
        // do some more filtering
    
        return filteredLedgers;
    }
