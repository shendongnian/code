    var percentages = schoolFeesResult
        .Select(x => new { SFR = x, AmoundDivFees = (x.Amount.Value / totalFees)})
        .Select(x => new { 
            TuitionFee = x.AmoundDivFees * x.SFR.TuitionFee.Value,
            TravellingFee = x.AmoundDivFees * x.SFR.TravellingFee.Value,
            ResidentialFee = x.AmoundDivFees * x.SFR.ResidentialFee.Value
        });
    return new SchoolFees(
        new Percentage(percentages.Sum(x => x.TuitionFee)),
        new Percentage(percentages.Sum(x => x.TravellingFee)),
        new Percentage(percentages.Sum(x => x.ResidentialFee)));
