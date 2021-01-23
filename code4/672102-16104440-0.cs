    public static List<OnderzoekColumn> GetOnderzoekColumns(int onderzoekId)
    {
     var store = DynamicDataStoreFactory.Instance.GetStore(typeof(OnderzoekColumn));
     var query = from item in store.Items<OnderzoekColumn>()
                 where item.OnderzoekId == onderzoekId
                 select item;
     return query.ToList();
    }
