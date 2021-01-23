        @for(var i = 0;i<Model.RuleItemList.Count;++i)
        {
            @Html.TextBoxFor(m => m.RuleItemList[i].Name);
        }
        @Html.EditorFor(m = > m.RuleViewModel.PropertyOne);
        @Html.EditorFor(m = > m.RuleViewModel.PropertyTow);
        @Html.EditorFor(m = > m.RuleViewModel.PropertyThree);
