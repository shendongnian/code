    var codequery = from a in ICDUnitOfWork.Alphas.Find()
                    join c in ICDUnitOfWork.Codes.Find()
                    on a.CodeID equals c.CodeID into g
                    select new HomeSearchViewModel
                           {
                              Alphas = null,
                              AlphaGroups = null,
                              AlphaGroupCode = null,
                              SearchTerm = null,
                              AlphasCodes = g
                           };
    
    var allResults = queryNew.Concat(codequery);
