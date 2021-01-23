    @(Html.Kendo().Grid<BillParent>()
        .Name("BillParentsGrid")
        .Columns(columns =>
        {
            columns.Bound(h => h.Category).Width(50);
            columns.Bound(h => h.Description);
            columns.Bound(h => h.Amount).Width(80);
            columns.Command(command =>
            {
                command.Edit();
            })
            .Title("Commands").Width(150);
        })
        .DataSource(dataSource => dataSource
            .Ajax()
            .Model(model =>
            {
                model.Id(h => h.BillId);
                model.Field(h => h.BillId).Editable(false);
            })
            .Events(events => events.Error("error_handler"))
            .Read(read => read.Action("BillParents_Read", "Bill"))
            .Update(update => update.Action("BillParent_Update", "Bill"))
        )
        .Events(events => events.DataBound("dataBound"))
        .ClientDetailTemplateId("BillChildren")
    
          )
    
    <script id="BillChildren" type="text/kendo-tmpl">
        @(Html.Kendo().Grid<BillChild>()
              .Name("BillChildren_#=BillId#")
              .Columns(columns =>
              {
                  columns.Bound(d => d.BillId).Width(50);
                  columns.Bound(d => d.Description).Width(150);
                  columns.Bound(d => d.Amount).Width(80);
                  columns.Command(command =>
                  {
                      command.Edit();
                      command.Destroy();
                  })
                      .Title("Commands").Width(150);
              })
              .DataSource(dataSource => dataSource
                  .Ajax()
                  .Model(model =>
                  {
                      model.Id(d => d.BillId);
                      model.Field(d => d.BillId).Editable(false);
                  })
                  .Events(events =>
                  {
                      events.Error("error_handler");
                      **events.Sync("resyncParentGrid");**
                  })
                  .Read(read => read.Action("BillChildren_Read", "Bill", new { id = "#=BillId#" }))
                  .Update(update => update.Action("BillChild_Update", "Bill"))
                  .Create(create => create.Action("BillChild_Create", "Bill", new { id = "#=BillId#" }))
                  .Destroy(destroy => destroy.Action("BillChild_Destroy", "Bill"))
              )
              .ToolBar(tools => tools.Create())
              .ToClientTemplate()
              )
    </script>
    
    
    
    <script>
        function dataBound() {
            this.expandRow(this.tbody.find("tr.k-master-row").first());
        }
    
        function resyncParentGrid(e) {
            var parentData = $('#BillParentsGrid').data("kendoGrid");
            parentData.dataSource.read();
        }
    </script>
