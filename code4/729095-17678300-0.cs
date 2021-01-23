    if(columnName == "MextText")
    {
        return list.GroupBy(x => x.MenuText);
    }
    if(columnName == "RoleName")
    {
        return list.GroupBy(x => x.RoleName);
    }
    if(columnName == "ActionName")
    {
        return list.GroupBy(x => x.ActionName);
    }
    return list.GroupBy(x => x.MenuText);
