    public VisitEntry Get(Guid visitEntryId)
    {
        var visitEntry = _visitEntryRepository.Get(visitEntryId);
        visitEntry.CasePartyIds =
            _casePartyService.GetAllForHearingEntry(visitEntryId).Select(caseParty => caseParty.CasePartyId).ToList();
        return visitEntry;
    }
