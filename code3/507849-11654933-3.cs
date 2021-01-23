    @model CustomerViewModel
    @using(Html.BeginForm())
    {
      <h2>@Model.Name</h2>
      <p>@Model.Address.AddressLine1</p>
      @foreach(var order in Model.Orders)
      {
        <p>@order.OrderID.ToString()</p>
      }
    
    }
