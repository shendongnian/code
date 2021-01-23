    public ActionResult ActionA()
    {
       var dto = TempData["model"] as DTOA;
       ...
    }
    [HttpPost]
    public ActionResult ActionB(DTOB dtoB)
    {
        DTOA dto = new DTOA();
        dto.ArraOfStringA = dtoB.ArraOfStringB;
        dto.Id = dtoB.Id;
        TempData["model"] = dto;
        return RedirectToAction("ActionA");
    }
