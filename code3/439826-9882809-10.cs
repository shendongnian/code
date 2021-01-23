    @model ORderViewModel
    @using (Html.BeginForm())
    {
      <p> 
        @Html.DropDownListFor(x => x.SelectedProductId ,
                         new SelectList(Model.Products, "ID", "Name"), "-- Select Product--")
      </p>
      <input type="submit" />
    }
