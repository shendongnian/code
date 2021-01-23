    using (new Sitecore.SecurityModel.SecurityDisabler())
    {
        item.Editing.BeginEdit();
        item[Sitecore.FieldIDs.Created] = Sitecore.DateUtil.ToIsoDate(DateTime.Now);
        item.Editing.EndEdit();
    }
