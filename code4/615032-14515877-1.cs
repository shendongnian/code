    public JsonResult RefreshDepartments()
    {
        return Json(GetDepartments, JsonRequestBehavior.AllowGet);
    }
    private SelectList GetDepartments
    {
        var deparments = GetDepartments;
        SelectList list = new SelectList(departments);
        return list;
    }
