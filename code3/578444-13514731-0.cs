    IEnumerable<Item> GetItems()
    {
        while (Service.HasMorePages())
        {
            foreach (Item item in Service.GetNextPage())
            {
                yield return item;
            }
        }
        yield break;
    }
