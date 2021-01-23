    var query = listA.Join(listB, item => item.ID, item => item.ID,
        (a, b) => new
        {
            ID = a.ID,
            IsChipCollected = a.IsChipCollected | b.IsChipCollected,
            IsShirtCollected = a.IsShirtCollected | b.IsShirtCollected,
            IsPackCollected = a.IsPackCollected | b.IsPackCollected,
        });
