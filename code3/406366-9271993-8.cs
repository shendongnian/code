    public ActionResult DrawControl(string id, ...)
    {
        // FieldControl being the name of my Model
        var viewModel = new FieldControl() { ID = id, ... };
        if (shouldRenderAudit)
            return PartialView("AuditControl", viewModel);
        else
            return PartialView("ReviewControl", viewModel);
