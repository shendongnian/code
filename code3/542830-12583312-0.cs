    <% using (Html.BeginForm()) { %>
        <% for (var i = 0; i < Model.AllPages.Count; i++) { %>
        <fieldset>
            <legend>
                <%= Model.AllPages[i].DisplayName %>
            </legend>
            <% for (var j = 0; j < Model.AllPages[i].actions.Count; j++ ) { %>
                <%= Html.CheckBoxFor(x => Model.AllPages[i].actions[j].IsChecked) %>
                <%= Html.Label(Model.AllPages[i].actions[j].DisplayName) %>
            }
        </fieldset>
        <% } %>
        <input type="submit" value="save"/>
    <% } %>
