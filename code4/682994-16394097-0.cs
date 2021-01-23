    public ViewResult List(string city, string firstName, int page = 1)
    {
        var query = repository.Userss.Where(p => city == null || p.CityName == city);
        if (firstName != null)
            query = query.Where(p => firstName == null || p.FirstName == firstName);
        var model = new UsersListViewModel
        {
            Users = query
            .OrderBy(p => p.UsersId)
            .Skip((page - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                UsersPerPage = PageSize,
                TotalUsers = repository.Userss.Count()
            },
            CurrentCity = city
            // CurrentFirstName = firstName
        };
        return View(model);
    }
