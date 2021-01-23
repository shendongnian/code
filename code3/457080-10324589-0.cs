    public List<claim> GetFilteredClaims(string submissionId, string claimId,
                                         string organization, string status,
                                         string filterFromDate, string filterToDate,
                                         string region, string approver)
    {
        IQueryable<claim> filteredClaims = _db.claims;
    
        if (!string.IsNullOrWhiteSpace(submissionId))
        {
            filteredClaims = filteredClaims.Where(claim => claim.submissionId == submissionId);
        }
    
        if (!string.IsNullOrWhiteSpace(claimId))
        {
            filteredClaims = filteredClaims.Where(claim => claim.claimId == claimId);
        }
    
        ...
    
        return filteredClaims.ToList();
    }
