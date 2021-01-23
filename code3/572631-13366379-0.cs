    IEnumerable<ICD.ViewModels.HomeSearchViewModel> query = ICDUnitOfWork.AlphaGroups
        .Where(g => g.Title.Contains("baby"))
        .GroupJoin(ICDUnitOfWork.Alphas.Where(a => a.Title.Contains("baby"),
            a => a.AlphaGroupID,
            g => g.AlphaGroupID,
            (alphaGroups, alphas) =>
                new ICD.ViewModels.HomeSearchViewModel
                {
                    AlphaGroups = alphaGroups,
                    Alphas = alphas
                }).AsEnumerable();
