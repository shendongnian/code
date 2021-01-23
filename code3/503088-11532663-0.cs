    public IEnumerable<MenuTableObject> GetMenus ( int? parentId ) {
        var result = ( from m in _db.Menus
                       join ml in _db.MenuLanguages on m.Id equals ml.MenuId
                       join l in _db.Languages on ml.LanguageId equals l.Id
                       where l.Code == Thread.CurrentThread.CurrentCulture.Name
                             && m.ParentId == ( parentId.HasValue ? parentId : null )
                       select new MenuTableObject {
                           Action = m.Action,
                           Controller = m.Controller,
                           Id = m.Id,
                           Title = ml.Title
                       } ).ToList();
        foreach(var menu in result)
        {
            menu.SubMenus = this.GetMenus(menu.Id);
        }
        return result;
    }
