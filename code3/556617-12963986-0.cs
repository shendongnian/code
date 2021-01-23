    [HttpPost]
    [ActionName("Create")]
    public ActionResult CreatePost(Customer cust)
    {
        if (ModelState.IsValid)
        {
            _repository.Add(cust);
            return RedirectToAction("GetAllCustomers");
        }
        return View(cust);
    }
