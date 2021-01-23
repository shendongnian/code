    @model IEnumerable<ViewModels.MyViewModels>
    
            @{
                if (Model.Count() > 0)
                {            
     
                    @Html.DisplayFor(modelItem => Model.Theme.FirstOrDefault().name)
                    @foreach (var theme in Model.Theme)
                    {
                       @Html.DisplayFor(modelItem => theme.name)
                       @foreach(var product in theme.Products)
                       {
                          @Html.DisplayFor(modelItem => product.name)
                          @foreach(var order in product.Orders)
                          {
                              @Html.TextBoxFor(modelItem => order.Quantity)
                             @Html.TextAreaFor(modelItem => order.Note)
                              @Html.EditorFor(modelItem => order.DateRequestedDeliveryFor)
                          }
                      }
                    }
                }else{
                       <span>No Theam avaiable</span>
                }
            }
