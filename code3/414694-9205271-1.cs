    // get all errors
    var viewModel = _errorsRepository.Errors;
    // optionally filter            
    if (!String.IsNullOrEmpty(searchError))
    {
        string searchErrorMatch = searchError.Trim().ToLower();
        viewModel = viewModel.Where(e => e.Message.ToLower().Contains(searchErrorMatch));
    }
    //order and project to ErrorViewModel
    viewModel = viewModel.OrderByDescending(e => e.TimeUtc)
                         .Select(e => new ErrorViewModel
                          {
                              ErrorId = e.ErrorId,
                              Message = e.Message,
                              TimeUtc = e.TimeUtc
                          });
