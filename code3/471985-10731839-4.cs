    public ViewResult List(int page = 1)
    {
        EmployeListViewModel viewModel = new EmployeListViewModel
        {
            Employes = GetStuff(page, PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                itemsPerPage = PageSize,
                TotalItems = repository.Сотрудник.Count()
            }
        };
        return View(viewModel);
    }
