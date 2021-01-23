    using System.Collections.Async;
    ...
    await ids.ParallelForEachAsync(async i =>
    {
        ICustomerRepo repo = new CustomerRepo();
        var cust = await repo.GetCustomer(i);
        customers.Add(cust);
    },
    maxDegreeOfParallelism: 10);
