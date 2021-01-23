    List<Item> items = new List<Item> {
        new Wood { Condition = Wood.Rotten },
        new Wood { Condition = Wood.Epic },
    };
    // We find the EXISTING objects that we already have ..
    var woodToBurn = items.OfType<Wood>
        .Where(w => w.Condition == Wood.Rotten);
    // .. so we can remove them
    foreach (var wood in woodToBurn) {
       items.Remove(wood);
    }
