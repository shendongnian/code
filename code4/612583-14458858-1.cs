    var fees = from fee in schoolFeesResult
               let weight = fee.Amount.Value / totalFees
               select new 
               {
                   TuitionFee = weight * fee.TuitionFee.Value,
                   TravellingFee = weight * fee.TravellingFee.Value,
                   ResidentialFee = weight * fee.ResidentialFee.Value
               };
    // if the calculation of the fees is a performance bottleneck,
    // uncomment the next line:
    // fees = fees.ToList();
    return new SchoolFees(
        new Percentage(fees.Sum(x => x.TuitionFee),
        new Percentage(fees.Sum(x => x.TravellingFee),
        new Percentage(fees.Sum(x => x.ResidentialFee));
