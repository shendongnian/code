        @model MvcApplication.Models.DataModel
        <ol id="@Model.DataCategorieLevel">
        @for (var i = 0; Model.Data.Count > i; i++)
        {
            <li value="@Model.Data[i].ItemId" onclick="itemSelected(@Model.Data[i].ItemId, @Model.DataCategoryLevel);" >@Model.Data[i].ItemName</li>
        }
        </ol>
