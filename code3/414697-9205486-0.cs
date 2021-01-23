    public ActionResult Index(string searchError)
    {
        // get all errors
        var viewModel = _errorsRepository.Errors.OrderByDescending(e => e.TimeUtc)
            .Where(e => String.IsNullOrEmpty(searchError)
                        || e.Message.ToLower().Contains(searchError.Trim().ToLower())
            ).Select(
                e => new ErrorViewModel {
                    ErrorId = e.ErrorId,
                    Message = e.Message,
                    TimeUtc = e.TimeUtc
                }
            );
        return View(viewModel);
    }
