    //This will make a Model property of the View to be of MyClassModel
    @model MyNamespace.Models.MyClassModel // strongly-typed view
    // @model IList<MyNamespace.Models.MyClassModel> // list, strongly-typed view
    // ... Some Other Code ...
    @using(Html.BeginForm()) // Creates <form>
    {
        // Renders hidden field for your model property (strongly-typed)
        // The field rendered to server your model property (Address, Phone, etc.)
        Html.HiddenFor(model => Model.MyPropertyForHidden); 
        // For list you may use foreach on Model
        // foreach(var item in Model) or foreach(MyClassModel item in Model)
    }
    // ... Some Other Code ...
