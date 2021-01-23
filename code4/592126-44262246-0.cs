    @{
       var parameters = new RouteValueDictionary();
       for (var i = 0; i < Model.CustomList.Count; ++i)
       {
           parameters.Add($"customListId[{i}]", Model.CustomList[i]);
       }
    }
