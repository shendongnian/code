    [HttpPost]
    public ActionResult Search(SearchViewModel viewModel)
    {
         // Check for null viewModel
    
         if (!ModelState.IsValid)
         {
              // A possible failed validation is when no search string was entered,
              // and then you don't want to do any database calls.
              // Just pass back the view model and let the view handle the displaying of errors
              
              return View(viewModel);
         }
         // If validation succeeds now you can use your search string to retrieve data
         searchService.Search(viewModel.SearchString);
         // Do what else you need to do and the return the correct view
         return View();
    }
