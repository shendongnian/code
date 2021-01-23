    public ActionResult Kittens()
    {
        var result = kittenService.GetKittens()
            .ToKittenListViewModel(10, 10);
        return Json(result,JsonRequestBehavior.AllowGet);
    }
