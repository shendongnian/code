        #region build query
        
        var query = new List<BaseQuery>
                    {
                        Query<IAuthForReporting>.Range(r => r.OnField(f => f.AuthResult.AuthEventDate)
                                                        .From(authsByDateInput.StartDate.ToEPCISFormat())
                                                        .To(authsByDateInput.EndDate.ToEPCISFormat()))
                    };
        if (authsByDateInput.AuthResult != AuthResultEnum.SuccessOrFailure)
        {
            var success = authsByDateInput.AuthResult == AuthResultEnum.Success;
            query.Add(Query<IAuthForReporting>.Term(t => t.AuthResult.AuthenticationSuccessful, success));
        }
        if (authsByDateInput.ProductID != null)
        {
            query.Add(Query<IAuthForReporting>.Term(t => t.AuthResult.ProductID, authsByDateInput.ProductID.Value));
        }
        if (!authsByDateInput.CountryIDs.IsNullOrEmpty())
        {
            query.Add(Query<IAuthForReporting>.Terms(t => t.AuthResult.Address.CountryID, authsByDateInput.CountryIDs.Select(x=> x.Value.ToString()).ToArray()));
        }
        #endregion
            var result =
                ElasticClient.Search<IAuthForReporting>(s =>
                                                        s.Index(IndexName)
                                                         .Type(TypeName)
                                                         .Size(0)
                                                         .Query(q =>
                                                                q.Bool(b =>
                                                                       b.Must(query.ToArray())
                                                                    )
                                                            )
                                                         .FacetDateHistogram(t => t.OnField(f => f.AuthResult.AuthEventDate).Interval(DateInterval.Day))
                    );
