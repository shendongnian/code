    public ActionResult aSavePageCopy(MyViewModel model)
    {
        aLoggedIn();
        PagesDataContext pdc = new PagesDataContext();
        Page p = pdc.Pages.Single(row => row.ID == model.Id);
    
        p.PageCopy = Model.PageCopy;
    
        pdc.SubmitChanges();
    
        return Redirect("/Admin/aViewPages");
    }
