    var data = new[] { 
        new ResultsSet {
            UID = 1,
            RelatedSet = new[] {
                new RelatedItems { Item_ID = 2 },
                new RelatedItems { Item_ID = 3 },
            },
        },
        new ResultsSet {
            UID = 2,
        },
        new ResultsSet {
            UID = 3,
        },
    };
    var items = data.Select(MapResultSet(data)).ToList();
    Debug.Assert(items.Count == 3);
    Debug.Assert(items[0].UniqueId == 1);
    Debug.Assert(items[1].UniqueId == 2);
    Debug.Assert(items[2].UniqueId == 3);
    Debug.Assert(items[0].RelatedItems.Count == 2);
    Debug.Assert(items[0].RelatedItems[0].UniqueId == items[1].UniqueId);
    Debug.Assert(items[0].RelatedItems[1].UniqueId == items[2].UniqueId);
