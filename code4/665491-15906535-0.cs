    using (new Sitecore.SecurityModel.SecurityDisabler())
    {
        item.Editing.BeginEdit();
        item[Sitecore.FieldIDs.CreatedBy] = Sitecore.DateUtil.ToIsoDate(DateTime.Now);
        item.Editing.EndEdit();
    }
