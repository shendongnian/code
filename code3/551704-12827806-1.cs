    // Get the partitioner.
    OrdinalPartitioner<MyItem> partitioner = Partitioner.Create(items);
    
    // Get the partitions.
    // You'll have to set the parameter for the number of partitions here.
    // See the link for creating custom partitions for more
    // creation strategies.
    IList<IEnumerator<MyItem>> paritions = partitioner.GetPartitions(
        Environment.ProcessorCount);
    
    // Create a task for each partition.
    Task[] tasks = partitions.Select(p => Task.Run(() => { 
            // Create the context.
            using (var ctx = new MyDbContext())
            // Remember, the IEnumerator<T> implementation
            // might implement IDisposable.
            using (p)
            // While there are items in p.
            while (p.MoveNext())
            {
                // Get the current item.
                MyItem current = p.Current;
    
                // Call the stored procedures.  Process the item
                ctx.DoSomething1(current);
                ctx.DoSomething2(current);
            }
        })).
        // ToArray is needed (or something to materialize the list) to
        // avoid deferred execution.
        ToArray();
