    @model IEnumerable<ns.Models.Property>
    @{
        if (Model != null && Model.Count > 0)
        {
            var testWebGrid = new WebGrid(Model, canPage: true, rowsPerPage: 10, ajaxUpdateContainerId: "testTableDiv");
            <div id="testTableDiv">
               <div id="testGridDiv">
                   @testWebGrid.GetHtml(mode: WebGridPagerModes.All, footerStyle: "pager")
                </div>
                @testWebGrid.Pager()
             </div>
        }
     }
