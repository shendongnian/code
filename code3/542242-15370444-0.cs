            @(Html.Kendo().Grid<OrdersViewModel>()
                  .Name("Orders")
                  .HtmlAttributes(new {style = "height: 100%; border-width: 0;"})
                  .Columns(c =>
                      {
                         c.Bound(p => p.Id)
                         .Width(50)
                      }
                 .Editable(editable =>
                      {
                         editable.Mode(GridEditMode.InLine);
                         editable.DisplayDeleteConfirmation("Your Message here");
                      }))
