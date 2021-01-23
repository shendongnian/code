    @model Int32
    @Html.DropDownListFor(x => x, new SelectList(
      Customers.GetAllCustomers().Select(y => new SelectListItem {
        Value = y.Id,
        Text = y.Name,
        Selected = Model == y.Id
      })
    );
