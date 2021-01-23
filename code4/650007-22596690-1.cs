    <div id="ssGrid">
        @{
            var grid = new WebGrid(canPage: false, canSort: false);
            grid.Bind(
                source: Model,
                columnNames: new[] { "Location", "Number" }
            );
        }
        @grid.GetHtml(
            tableStyle: "webGrid",
            headerStyle: "header",
            alternatingRowStyle: "alt",
            columns: grid.Columns(
                grid.Column("Location", "Location"),
                grid.Column("Number", "Number"),
                grid.Column(
                    format: (item) => 
                        new MvcHtmlString(string.Format("<span id='ssGrid{0}'>{1}</span>",
                                              item.SecondarySystemId,
                                              @Ajax.RouteLink("Delete",
                                                  "Detail", // route name
                                                  new { action = "DeleteSecondarySystem", actionId = item.SecondarySystemId },
                                                  new AjaxOptions { 
                                                      OnComplete = "removeRow('ssGrid" + item.SecondarySystemId + "')"
                                                  }
                                              )
                                         )
                        )
                )
            )
        )
    </div>
    <script>
        function removeRow(rowId) {
            $("#" + rowId).closest("tr").remove();
        }
    </script>
