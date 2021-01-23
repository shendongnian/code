    //collect two-pair items
    var result = from KeyValuePair<int, Tuple<Quality, Item>> virtQ2I_1
                        in QualitiesToItems
             join KeyValuePair<int, Tuple<Quality, Item>> virtQ2I_2
                     in QualitiesToItems
             on virtQ2I_1.Value.Item1.name equals virtQ2I_2.Value.Item1.name
             where (virtQ2I_1.Value.Item2.name != virtQ2I_2.Value.Item2.name)
             select new List<Item> {
                        virtQ2I_1.Value.Item2, 
                        virtQ2I_2.Value.Item2
                        };
    List<List<Item>> ItemsForSets = result.ToList();
    
    // self-join raw two-pair item list to generate three-set items
    result =    from List<Item> leftSide in ItemsForSets 
            join List<Item> rightSide in ItemsForSets
            on leftSide[1] equals rightSide[0]
            where (leftSide[0] != rightSide[1])
            select new List<Item> {
                        leftSide[0], 
                        leftSide[1],
                        rightSide[1]
                        };
    
    ItemsForSets.AddRange(result.ToList());
    
    // clean up results - preventing A:B and B:A from being considered unique,
    //    and ensuring all third ingredients actually contribute to a relationship.
    foreach (List<Item> items in ItemsForSets)
    {
        List<Quality> sharedQualities = Item.SharedQualities(this, items.ToArray());
        sharedQualities.Sort();
        List<String> sortedItems = items.ConvertAll(item => item.name); // I need the string names elsewhere 
        // TODO: I should rewrite to work directly with Items and convert after confirming I actually need the item.
        sortedItems.Sort(); // first part of preventing A:B B:A problems
        if (!Sets.ContainsKey(String.Join(", ", sortedItems))) // Dictionary provides second part.
        {
            if (items.Count == 3)
            {
                List<Quality> leftPairQualities = Item.SharedQualities(this, items.GetRange(0, 2).ToArray());
                leftPairQualities.Sort();
                if (leftPairQualities.SequenceEqual(sharedQualities))
                { // if the third item does not add a new quality
                    continue; // short circuit out to the next item
                }
            }
            // otherwise add to the list.
            Sets.Add(String.Join(", ", sortedItems), new Potion(items, sharedQualities));
        }
    }
