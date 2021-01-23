    @model ViewModel
    
    @using (Html.BeginForm("SendData", "Home", FormMethod.Post))
    {
        @Html.Grid(Model.List).Columns(c =>
        {
            c.For(x => x.Id);
            c.For(x => x.Name);
            c.For(x => Html.Partial("Partial/CheckBoxTemplate", x)).Named("Options");
        })
    
        <button type="submit">OK</button>
    }
