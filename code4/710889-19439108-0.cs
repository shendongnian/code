    var predicate = PredicateBuilder.False<ClientXMemberDetail>();
    predicate = predicate.Or(x => strArrselectedCustomMemberNumbers.Any<string>(y => x.MemberID.Contains(y)));
    CustomSearchMembersAlreadyMatched = ClientXContext.ClientXMemberDetails
                            .AsExpandable()
                                .Where(predicate)
                                .ToList()
                                .Select(r => r.MemberID.ToString()).ToList();
