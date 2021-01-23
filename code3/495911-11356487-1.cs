    <!-- Current Buildings -->
    @{ 
        if (Model != null && Model.Count() > 0)
        {                            
            var grid = new WebGrid(source: Model, rowsPerPage: ThisController.PageSize, ajaxUpdateContainerId: "tabs-2", defaultSort: "BuildingNumber");
            grid.Bind(Model, rowCount: Model.Count(), autoSortAndPage: false);
            grid.Pager(WebGridPagerModes.All);
            grid.GetHtml(
                tableStyle: "display",
                alternatingRowStyle: "alt",
                columns: grid.Columns(
                    grid.Column("BuildingNumber", header: "Building Number"),
                    grid.Column("ConstructionDate", header: "Construction Date"),
                    grid.Column("ExtSquareFeet", header: "Exterior Sq. Ft."),
                    grid.Column("IntSquareFeet", header: "Interior Sq. Ft."),
                    grid.Column("IU_Avail", header: "IU Available"),
                    grid.Column("SpaceAvail", header: "Space Available"),
                    grid.Column("FixedAssetValue", header: "Fixed Asset Value"),
                    grid.Column("FixedEquipValue", header: "Fixed Equipment Value")
                )
            );   
        }
        else
        {
            @:There are no buildings at this facility.
        }
    }   
