	var ids = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
	var getCustomerBlock = new TransformBlock<string, Customer>(
		async i =>
		{
			ICustomerRepo repo = new CustomerRepo();
			return await repo.GetCustomer(i);
		}, new ExecutionDataflowBlockOptions
		{
			MaxDegreeOfParallelism = DataflowBlockOptions.Unbounded
		});
	var writeCustomerBlock = new ActionBlock<Customer>(c => Console.WriteLine(c.ID));
	getCustomerBlock.LinkTo(
		writeCustomerBlock, new DataflowLinkOptions
		{
			PropagateCompletion = true
		});
	foreach (var id in ids)
		getCustomerBlock.Post(id);
	getCustomerBlock.Complete();
	writeCustomerBlock.Completion.Wait();
