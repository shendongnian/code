    @model IEnumerable<CommandGridViewModel>
    @(Html.Telerik().Grid(Model)
            .Name("GridCommands")
            .DataKeys(keys =>
            {
                keys.Add(c => c.Id);
            })
            .Pageable(page =>
            {
                page.PageSize(10);
            })
         ...
        .DataBinding(dataBinding =>
        {
            dataBinding.Server()
                .Select("Index", "Commands");
            dataBinding.Ajax()
                .Select("AjaxIndex", "Commands").Enabled(true);
        })
