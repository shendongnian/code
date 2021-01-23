    public ActionResult SomeAction()
    {
        var currencies = _db.Currencies.ToList();
        var model = new MyViewModel
        {
            FromValues = currencies.Select(x => new SelectListItem { Value = x.BuyValue.ToString(), Text = x.Name }),
            ToValues = currencies.Select(x => new SelectListItem { Value = x.SellValue.ToString(), Text = x.Name })
        };
        return View(model);
    }
