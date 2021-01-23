    @model IEnumerable<PlayMvc.Models.FooBar>
    <fieldset>
        <legend>Legendary</legend>
        @using(Html.BeginForm("Test","Home", FormMethod.Post)){
            var groups = Model.GroupBy(x => x.GroupName).Select(x => x.First()) .ToList();
            for (int i = 0; i < groups.Count(); i++ )
            {
                <h3>@groups[i].GroupName</h3>
    
                @Html.EditorFor(x => groups[i])
            }
            <input type="submit" />
        }
    </fieldset>
