    @model IEnumerable<ns.Models.Property>
    
    @{
        WebGrid table = new WebGrid(Model, ajaxUpdateContainerId: "tablediv");
    
    }
    <div id="tablediv">
        @table.GetHtml()
    </div>
