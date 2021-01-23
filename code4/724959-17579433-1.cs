    [GridAction]
    public ViewResult AjaxIndex()
    {
       return View(new GridModel(GetCommands()));
    }
    private IQueryable<CommandGridViewModel> GetCommands()
    {
       return from r in contenxt.Commands
              select new { r.Id , r.Name , r.Status , r.Type };
    
    }
