    @model List<User>
    @using (Html.BeginForm("ViewUsers", "Admin", FormMethod.Post, new { enctype = "multipart/form-data" }))
    {
        @for (int i = 0; i < Model.Count; i++) {
           @Html.DisplayFor(m => m[i].Username)
           @:Is Admin: @Html.EditorFor(m => m[i].IsAdmin)
           @:Gold Coins: @Html.EditorFor(m => m[i].GoldCoins)
        }
        <input type="submit" value="Save"/>
    }
