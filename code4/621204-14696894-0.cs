    string searchString = string.Format("%{0}%", search);
    PPoint ppointAlias = null;
    PPFile ppFileAlias = null;
    var pointList = session.QueryOver<PPoint>(() => ppointAlias)
                           .JoinQueryOver<PPFile>(ppPoint => ppPoint.ImportFile, () => ppFileAlias)
                           .Where(
                                     Restrictions.On(() => ppointAlias.Name).IsLike(searchString))
                                                  ||
                                     Restrictions.On(() => ppointAlias.Code).IsLike(searchString))
                                                  ||
                                     Restrictions.On(() => ppFileAlias.FileName).IsLike(searchString))
                                  )
                            .List();
