    private void ProcessItems(IEnumerable<string> items)
    {
         // TODO: ..
    }
    var items = new List<string>(Enumerable.Range(0, 1000)
                                           .Select(i => i + "_ITEM"));
    var items1 = items.Where((item, index) => (index + 0) % 4 == 0);
    var items2 = items.Where((item, index) => (index + 1) % 4 == 0);
    var items3 = items.Where((item, index) => (index + 2) % 4 == 0);
    var items4 = items.Where((item, index) => (index + 3) % 4 == 0);
    var tasks = new Task[]
        {
           factory.StartNew(() => ProcessItems((items1))),
           factory.StartNew(() => ProcessItems((items2))),
           factory.StartNew(() => ProcessItems((items3))),
           factory.StartNew(() => ProcessItems((items4)))
        };
    Task.WaitAll(tasks);
