    public ActionResult MyActionName(int id)
    {
        RouteData.Values.Remove("Id");
        return View();
    }
