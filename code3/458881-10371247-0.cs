    @using (Html.BeginForm()) {
   
        <fieldset>
            <legend>MyClassViewModel</legend>
            @foreach (var item in Model.Columns){
                @Html.Label(item.Key)
                @Html.CheckBox(item.Key, item.Value)
            }
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>
    }
