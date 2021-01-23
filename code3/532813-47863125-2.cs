    var grid = new WebGrid(Model, canPage: true, rowsPerPage: 5, selectionFieldName: "selectedRow",ajaxUpdateContainerId: "gridContent");
            grid.Pager(WebGridPagerModes.NextPrevious);}
            <div id="gridContent">
            @grid.GetHtml(tableStyle: "webGrid",
                    headerStyle: "header",
                    alternatingRowStyle: "alt",
                    selectedRowStyle: "select",
                    columns: grid.Columns(
                    grid.Column("Id", "Id"),
                    grid.Column("Name", "Name"),
                    grid.Column("Description", "Description"),
                    
             )) 
        @if (grid.HasSelection)
             {
                 common= (test1.Models.common)grid.Rows[grid.SelectedIndex].Value;
                 <b>Id</b> @common.Artist.Id<br />
                 <b>Name</b>  @common.Album.Name<br />
                 <b>Description</b> @common.Album.Description<br />
                 
             }
    </div>
