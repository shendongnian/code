    SubmissionNote subNoteAlias = null, subNoteAliasMax =null;
    User userAlias = null;
    String[] userNames = new[]{"John","Joe"};
    
    var subquery =
        QueryOver.Of(() => subNoteAliasMax)
           .Where(subNote => subNote.Submission.Id == subNoteAlias.Submission.Id)
           .Select(Projections.Max<SubmissionNote>(subNote => subNote.CreatedOn));
    var result = session
     .QueryOver<SubmissionNote>(() => subNoteAlias)
     .WithSubquery.WhereProperty(subNote=>subNote.CreatedOn).Eq(subquery)
     .JoinQueryOver(
          subNote=>subNote.Creator
          ,()=>userAlias
          ,JoinType.InnerJoin
          ,Restrictions.In(Projections.Property(() => userAlias.Username ), userNames))
      .List();
