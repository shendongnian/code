    public readonly IEnumerable<SISOverlayItem> Items
    {
        get
        {
            SISOverlayItem myItem = intermediateList.DoSomeWork();
            yield return myItem;
        }
    }
