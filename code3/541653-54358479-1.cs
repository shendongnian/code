    /// <summary>
    /// keyed collection.
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public class cCultures : System.Collections.ObjectModel.KeyedCollection<string, cCulture>
    {
        protected override string GetKeyForItem(cCulture item)
        {
            return item.culture;
        }
    }
