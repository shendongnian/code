        public ViewResult List(string city, string firstName, int page = 1)
        {
            UsersListViewModel model = new UsersListViewModel
            {
                Users = repository.Userss
                .Where((p =>city == null || p.CityName == city ) && 
                 (p =>firstname == null || p.FirstName == firstName))
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
                CurrentFirstName = firstName
            };
            return View(model);
        }
