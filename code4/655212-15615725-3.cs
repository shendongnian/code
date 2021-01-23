    // using NHibernate.Criterion;
    // using NHibernate.Transform;
    
    session.CreateCriteria<JournalEntry>()
       .SetProjection(
           Projections.Sum<JournalEntry>(x => x.DebitAmount).As("Debits"),
           Projections.Sum<JournalEntry>(x => x.CreditAmount).As("Credits"),
           // you can use other aggregates
           // Projections.RowCount(),
           // Projections.Max<JournalEntry>(x => x.EffectiveDate)
        )
        .SetResultTransformer(Transformers.AliasToBean<JournalEntrySummary>())
        .UniqueResult<JournalEntrySummary>();
