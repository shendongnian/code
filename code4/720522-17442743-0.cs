    @model Object
    @using (Html.BeginForm())
    {
        @Html.ValidationSummary(true)
        <fieldset>
            <legend>@Model.GetLabel()</legend>
            @foreach (var property in Model.VisibleProperties())
            {
                using(Html.ControlGroupFor(property.Name)){
                    @Html.Label(property.Name)
                    @Html.Editor(property.Name)
                    @Html.ValidationMessage(property.Name, null)
                }
            }
            <button type="submit">Submit</button>
        </fieldset>
    }
