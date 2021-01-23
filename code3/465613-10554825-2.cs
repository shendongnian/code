    @model TestModel
    
    @{
        ViewBag.Title = "MyView";
    }
    
    <h2>MyView</h2>
    @using (Html.BeginForm())
    {
        <div>
              @Html.DropDownListFor(model => model.Gender, Model.GenderList)
        </div>
    }
