                var searchValues = new List<SearchValue<int>>();
                var distinctItemIds = new Dictionary<int, List<string>>();
    
                foreach (var item in searchValues)
                {
                    if (!distinctItemIds.ContainsKey(item.ItemId))
                    {
                        distinctItemIds.Add(item.ItemId, new List<string>());
                    }
    
                    // Add the value
                    distinctItemIds[item.ItemId].Add(item.Value);
                }
    
                // Put values back into your data object
                var finishedValues = new List<SearchValue<int>>();
    
                foreach (var keyValuePair in distinctItemIds)
                {
                    finishedValues.Add(new SearchValue<int>()
                    {
                        ItemId = keyValuePair.Key,
                        Values = keyValuePair.Value.ToArray()
                    });
                }
