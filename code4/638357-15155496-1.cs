    static void Main(string[] args)
    {
        GenerateRandomDataSomehow();
        var groupedParties = _parties.GroupBy(p => p.HasReservation)
        SeatParty(groupedParties.FirstOrDefault(g => g.Key == true));
        SeatParty(groupedParties.FirstOrDefault(g => g.Key == false));
    }
    
    private static void SeatParty(IEnumerable<Party> partyGroup)
    {
        if (partyGroup == null) return;
  
        foreach (var party in partyGroup.OrderBy(p => p.ArrivalTime))
        {
            var properTable = _tables.FirstOrDefault(t => t.SeatsCount == party.PersonsCount &&
                                                          t.Party == null);
            if (properTable == null) continue;
            properTable.Party = party;
        }
    }
