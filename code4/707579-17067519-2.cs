    var supressed = history
        .GroupBy(x => new {
            ApplicantId = x.ApplicantId,
            ProviderId = x.ProviderId
        })
        .Select(g => g.OrderBy(x => x.ApplicationDate).First());
