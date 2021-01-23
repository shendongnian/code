    @grid.GetHtml(
       htmlAttributes: new { cellspacing = "2px", cellpadding = "2px" },
       columns: grid.Columns(
          grid.Column("Id"),
          grid.Column("Description"),
          grid.Column("PacketQuantity"),
          grid.Column("ThickCover", format: (item) => {
             var p = item.Value as MvcApplication1.Models.Product;
             return Html.TextBox("ThickCover", p.ThickCover, new { @class = "thickCoverInput", @data_value = p.Id });
              }),
          grid.Column("ThinCover", format: (item) => {
             var p = item.Value as MvcApplication1.Models.Product;
             return Html.TextBox("ThickCover", p.ThinCover);
          })
       )
    )
