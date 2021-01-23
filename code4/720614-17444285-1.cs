        var items = Enumerable.Range(100, 510); // Pretend we have 50 items.
        int itemsPerPage = 20;
        foreach (var page in items.Partition(itemsPerPage))
        {
            Console.Write("Page " + page.Index + " items: ");
            foreach (var i in page.Items)
                Console.Write(i + " ");
            Console.WriteLine();
        }
