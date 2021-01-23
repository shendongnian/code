    var res = Session.QueryOver<EstimationItem>()
        .JoinQueryOver(x => x.Estimation)
        .Select(x => new EstimationWithDetail
        {
            Estimation = x.Estimation,
            Id = x.Id,
            FullName = x.Estimation.Customer.FirstName + x.Estimation.Customer.LastName
        })
        .List();
