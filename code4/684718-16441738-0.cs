    public List<SelectListItem> OnOffDDL
    {
        get
        {
            return OnOffDropDownHelper.OnOffList()
                .Select(s => new SelectListItem
                             {
                                 Text = s,
                                 Value = s,
                                 Selected = ServiceCondition == s
                             })
                .ToList();
        }
    }
