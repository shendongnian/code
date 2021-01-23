    [ValidateInput(false)]
    public ActionResult aSavePageCopy(FormCollection fc)
    {
        aLoggedIn();
        int id = Convert.ToInt32(fc["id"]);
        PagesDataContext pdc = new PagesDataContext();
        Page p = pdc.Pages.Single(row => row.ID == id);
        p.PageCopy = fc["PageCopy"];
        pdc.SubmitChanges();
        return Redirect("/Admin/aViewPages");
    }
