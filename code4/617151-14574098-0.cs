    public virtual ActionResult ControllerName(Status? status = null)
    {
       if (status.HasValue) { /* some logic */ }
       return View();
    }
