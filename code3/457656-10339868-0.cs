        public ViewResult List(string category, int page = 1) {
            ProductsListViewModel viewModel = new ProductsListViewModel {
                Products = repository.Products
                    .Where(p => category == null ? true : p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo {
                    CurrentPage = page,
                    ItemsPerPage = PageSize, //4 for example
                    TotalItems =  category == null ? 
                        repository.Products.Count() : 
                        repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(viewModel);
        }
