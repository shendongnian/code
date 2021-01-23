    static Func<RelatedItems, DTOItem> MapRelated(IEnumerable<ResultsSet> all) {
        var map = MapResultSet(all);
        return relatedItem => map(all.First(x => x.UID == relatedItem.Item_ID));
    }
    static Func<ResultsSet, DTOItem> MapResultSet(IEnumerable<ResultsSet> all) {
        return s => 
            new DTOItem {
                ID = s.ResultId.GetOrElse(0).ToString(),
                UniqueId = s.UID,
                Payload = s.ResultBlob,
                RelatedItems = (s.RelatedSet ?? new RelatedItems[0]).Select(MapRelated(all)).ToList()
            };
    }
