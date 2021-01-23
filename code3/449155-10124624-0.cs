    using System.Threading.Tasks;
    ...
    var task = Task<TResult>.Factory.FromAsync(
        service.BeginSomething, service.EndSomething, arg1, arg2, ..., null);
    task.Wait();
    var result = task.Result;
