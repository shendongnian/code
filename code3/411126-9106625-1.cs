    @model YourViewModel
    
    
    @{
        foreach (string CurrCategory in Model.PossibleCategories)
        {
            if (Model.YourData.Category == CurrCategory)
                Html.CheckBoxFor(m => m.YourData.Category, new { checked = "checked" });
            else
                Html.CheckBox(CurrCategory, false);
        }
    }
