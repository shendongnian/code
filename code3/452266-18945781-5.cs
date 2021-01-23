    @model GoodHousekeeping.MVC.Models.ViewIngredientPageModel
    @foreach (var category in Model.ViewIngredientCategoryModels)
    {
        <p>@category.IngredientCategoryName</p>
        var category1 = category;
        var viewIngredientModels = (from i in Model.ViewIngredientModels
                     where i.IngredientCategoryId == category1.IngredientCategoryId
                     select i);
                       
        @Html.DisplayFor(m => viewIngredientModels)
    }
