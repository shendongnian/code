    // One common action that is used to determine which control should be drawn
    public ActionResult DrawControl(FieldControl model)
    {
        if (shouldRenderAudit)
            return PartialView("AuditControl", model);
        else
            return PartialView("ReviewControl", model);
    }
