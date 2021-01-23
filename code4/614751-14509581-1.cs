    var pendingFeedbackStatus = Session.QueryOver<FeedbackStatus>().Where(fs => fs.Name == "pending").SingleOrDefault();
    Domain.Feedback.Feedback feedbackAlias = null;
    FeedbackType feedbackTypeAlias = null;
    var allFeedback = QueryOver.Of<Domain.Feedback.Feedback>()
        .Where(f => f.Type.Id == feedbackTypeAlias.Id)
        .Where(f => !f.IsArchived);
    var pendingFeedback = QueryOver.Of<Domain.Feedback.Feedback>()
        .Where(f => f.Type.Id == feedbackTypeAlias.Id)
        .Where(f => !f.IsArchived)
        .Where(f => f.Status.Id == pendingFeedbackStatus.Id);
    if (project != null)
    {
        allFeedback.Where(f => f.Project.Id == project.Id);
        pendingFeedback.Where(f => f.Project.Id == project.Id);
    }
    FeedbackTypeSummary result = null;
    var query = Session.QueryOver<Domain.Feedback.Feedback>(() => feedbackAlias)
        .Right.JoinAlias(f => f.Type, () => feedbackTypeAlias, ft => !ft.IsRestricted)
        .SelectList(list => list
            .SelectSubQuery(allFeedback.ToRowCountQuery()).WithAlias(() => result.AllFeedbackCount)
            .SelectSubQuery(pendingFeedback.ToRowCountQuery()).WithAlias(() => result.PendingFeedbackCount)
            .SelectGroup(() => feedbackTypeAlias.Id).WithAlias(() => result.TypeId)
            .SelectGroup(() => feedbackTypeAlias.Name).WithAlias(() => result.TypeName)
            .SelectGroup(() => feedbackTypeAlias.NamePlural).WithAlias(() => result.TypeNamePlural)
            .SelectGroup(() => feedbackTypeAlias.SortOrder)
        )
        .OrderBy(() => feedbackTypeAlias.SortOrder).Asc
        .TransformUsing(Transformers.AliasToBean<FeedbackTypeSummary>());
    var results = query.List<FeedbackTypeSummary>();
    return results;
