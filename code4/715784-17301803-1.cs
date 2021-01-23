    var results = new ConcurrentBag<ItemType>(result.pagination.totalPages);
    using (var e = new CountdownEvent(result.pagination.totalPages))
    {
        for (int i = 2; i <= result.pagination.totalPages+1; i++)
        {
            Task.Factory.StartNew(() => return client.findItemsByProduct(i))
                        .ContinueWith(items => {
                            results.AddRange(items);
                            e.Signal(); // signal task is done
                        });
        }
        // Wait for all requests to complete
        e.Wait();
    }
    // Process results
    foreach (var item in results) 
    {
        ...
    }
