    private async Task<List<T>> FindItems(...)
    {
        int total = result.paginationOutput.totalPages;
        var newList = new List<T>();
        for (int i = 2; i < total + 1; i++)
        {
            IEnumerable<T> result = await Task.Factory.StartNew(() =>
            {
                return client.findItemsByProduct(i);
            });
            newList.AddRange(result.searchResult.item);
        }
        return newList;
    }
