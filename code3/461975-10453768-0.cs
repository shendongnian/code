    @{
        var dict = new RouteValueDictionary();
        for (int i = 0; i < Model.A.Count; i++)
        {
            dict.Add("a[" + i + "]", Model.A[i]);
        }
    }
    @Html.ActionLink("Click here", "Foo", dict);
   
