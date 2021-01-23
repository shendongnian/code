    @{
        var resultArray = Model.SearchResult.ToArray(); // only necessary if SearchResult is not a list or array
    }
    @for(var i = 0; i < resultArray.Length; i++)
    {
        var item = resultArray[i];
        if (i % 2 == 0)
        {
            <span>Row @(i / 2)</span>
        }
        <span>| @item.Address.TownCity</span>
    }
