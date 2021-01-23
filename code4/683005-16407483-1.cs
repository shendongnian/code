    <dl>
        @foreach (var prop in
            ViewData.ModelMetadata.Properties
                .Where(pm => pm.ShowForEdit && !ViewData.TemplateInfo.Visited(pm)))
        {
            <dt>@Html.Label(prop.PropertyName)</dt>
            <dd>
                @Html.Editor(prop.PropertyName)
                @Html.ValidationMessage(prop.PropertyName)
            </dd>
        }
    </dl>
