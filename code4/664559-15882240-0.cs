    [Authorize]
    [HttpPost]
    public ActionResult Action(string selectedBookId)
    {
        if (ValidateFields()
        {
            Book book = FetchYourBookFromTheId(selectedBookId);
            var data = GetDatasAboutBookSelected(book);
            ViewBag.Data = data;
            return View();
        }
        return View();
    }
