    GenerateOrClause(Enumerable.Empty<ResultObject>().AsQueryable(),
                     new List<Conditions> { Conditions.ByAlpha });
    // (c.AlphaValue)
    GenerateOrClause(Enumerable.Empty<ResultObject>().AsQueryable(),
                     new List<Conditions> { Conditions.ByAlpha, Conditions.ByBeta });
    // (c.AlphaValue OrElse c.BetaValue)
    GenerateOrClause(Enumerable.Empty<ResultObject>().AsQueryable(),
                     new List<Conditions> { Conditions.ByAlpha, Conditions.ByBeta, Conditions.ByGamma });
    // (c.AlphaValue OrElse c.BetaValue OrElse c.GammaValue)
