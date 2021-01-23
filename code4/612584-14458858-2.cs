    var fees = (from fee in schoolFeesResult
                let weight = fee.Amount.Value / totalFees
                group fee by 1 into g
                select new 
                {
                    TuitionFee = g.Sum(x => weight * x.TuitionFee.Value),
                    TravellingFee = g.Sum(x => weight * x.TravellingFee.Value),
                    ResidentialFee = g.Sum(x => weight * x.ResidentialFee.Value)
                }).Single();
    return new SchoolFees(
        new Percentage(fees.TuitionFee,
        new Percentage(fees.TravellingFee,
        new Percentage(fees.ResidentialFee);
