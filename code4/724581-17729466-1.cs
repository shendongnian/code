    public ActionResult Kittens()
    {
        var result = kittenService.GetKittens()
            .Where(kitten => kitten.fluffiness > 10) 
            .OrderBy(kitten => kitten.name)
            .Select(kitten => new {
                Name=kitten.name,
                Url=kitten.imageUrl
            })
            .Take(10);
        return Json(result,JsonRequestBehavior.AllowGet);
    }
