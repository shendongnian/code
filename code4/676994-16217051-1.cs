    public IList<DocumentEntry> GetDocumentEntriesForRateAdjustmentTry2(
        string username, Rate rate, List<RatePeriod> ratePeriods)
    {
        var dimensionLibManager = new DimensionLibManager();
        var currentVersionRateGroups = rate.CurrentRateVersion.RateGroups.ToList();
    
        Expression<Func<DocumentEntry, int, bool>> dimensionMatchesExpression =
            (documentEntry, rateGroups, dimensionInfoId) =>
            currentVersionRateGroups.Any(
                rg =>
                rg.Dimension1.All(character => character == '*')
                ||
                documentEntry.DocumentEntryDimensions.Any(
                    ded =>
                    ded.DimensionInfo.Position == dimensionInfoId
                    &&
                    dimensionLibManager.GetDimensionSegments(rate.CompanyId, username, dimensionInfoId, ded.Value).Any(
                        seg => ded.Value.Substring(seg.SegmentStart, seg.SegmentLength) == seg.SegmentValue)));
    
        var documentEntries = this.ObjectSet.Where(dimensionMatchesExpression);
    
        var result = documentEntries.ToList(); // The error happens here.
    
        return result;
    }
