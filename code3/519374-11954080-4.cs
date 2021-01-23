    public ActionResult aHome()
    {
      List<Nav> navList = HtmlHelpers.GetNavList();
      return View(navList);
    }
