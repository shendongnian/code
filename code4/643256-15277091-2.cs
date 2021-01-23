    [HttpPost]
    public ActionResult SomeAction(IEnumerable<ObjInfo> model)
    {
        var selectedItems = model.Where(x => x.m_IsSelected);
        ...
    }
