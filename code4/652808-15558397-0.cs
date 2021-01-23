    public IEnumerable<BrowseVendorModel> BrowseVendors()
    {
        IQueryable<BrowseVendorModel> viewModel = _db.VendorProfiles
            .Include("VendorsSelected")
            .Select(s => new BrowseVendorModel
            {
                ProfileID = s.ProfileID,
                Name = s.Name,
                CompanyName = s.CompanyName,
                City = s.City,
                State = s.State,
                DateCreated = s.DateCreated,
                Selected = x.VendorsSelected.Select(s => s.UserName)
                            .Contains(HttpContext.Current.User.Identity.Name)
            })
            .OrderBy(v => v.ProfileID);
        return viewModel;
    }
