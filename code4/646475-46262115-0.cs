     @foreach (var item in Model.Take(10))
        {
            <div id="eitt">
                <fieldset>
                    <legend>@Html.ActionLink( item.Name, "Edit", new { id=item.Id } )</legend>
                    <div>@item.Subject, @item.Created</div>
                    <p>@Html.Raw(item.Content.Replace(Environment.NewLine, "<br/>"))</p>
                </fieldset>
            </div>
        }
