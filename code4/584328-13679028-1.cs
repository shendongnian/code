    .JoinAlias(() => fieldAlias.Parent, () => parentFieldAlias
               , NHibernate.SqlCommand.JoinType.LeftOuterJoin)) // left join for NULL
    .Where
    (
      Restrictions.Or(
        Restrictions.On(() => fieldAlias.Parent).IsNull, // this is what we need
        Restrictions.On(() => parentFieldAlias.Value).IsLike(parentValue))
    );
