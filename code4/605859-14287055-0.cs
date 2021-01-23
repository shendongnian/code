    @model ViewModels.MyViewModels.Theme
    
    @Html.LabelFor(Model.Theme.name)
    @foreach (var category in Model.Theme)
    {
       @Html.LabelFor(category.name)
       @foreach(var product in theme.Products)
       {
          @Html.LabelFor(product.name)
          @foreach(var order in product.Orders)
          {
              @Html.TextBoxFor(order.Quantity)
              @Html.TextAreaFor(order.Note)
              @Html.EditorFor(order.DateRequestedDeliveryFor)
          }
       }
    }
