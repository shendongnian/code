    // determine the requests
    var subquery = QueryOver.Of<Request>()
        .WhereRestrictionOn(request => request.ReferralSource).IsIn(searchConditions.Units)
        .Where(request => request.PatientId != null)
        .JoinQueryOver(request => request.Examinations)
        .Where(examination => examination.Status.Value != null)
        .Where(examination => examinationAlias.Status.Value >= ExaminationStatus.Value.RequestSubmitted)
        .Skip((searchConditions.Page - 1) * searchConditions.PageSize)
        .Take(searchConditions.PageSize)
        .Select(r => r.Id);
    // load the requests with eagerly fetching the associations
    var results = Session.QueryOver<Request>()
        .WithSubquery.WhereProperty(request => request.Id).In(subquery)
        .Fetch(request => request.Creator).Eager
        .Fetch(request => request.Examinations).Eager
        .ToList();
