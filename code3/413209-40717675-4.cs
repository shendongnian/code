    public static class ContractsAbbreviators
    {
        [ContractAbbreviator]
        public static void EnsureTaskIsStarted()
        {
            Contract.Ensures(Contract.Result<Task>() != null);
            Contract.Ensures(Contract.Result<Task>().Status != TaskStatus.Created);
        }
    }
    [ContractClass(typeof(ContractClassForIFoo))]
    public interface IFoo
    {
        Task<int> MethodAsync(int val);
    }
    
    [ContractClassFor(typeof(IFoo))]
    internal abstract class ContractClassForIFoo : IFoo
    {
        public Task<int> MethodAsync(int val)
        {
            Contract.Requires(val >= 0);
            ContractsAbbreviators.EnsureTaskIsStarted();
            Contract.Ensures(Contract.Result<int>() == val);
            Contract.Ensures(Contract.Result<int>() >= 5);
            Contract.Ensures(Contract.Result<int>() < 10);
            throw new NotImplementedException();
        }
    }
    public class FooContractFailTask : IFoo
    {
        public Task<int> MethodAsync(int val)
        {
            return new Task<int>(() => val);
            // esnure raises exception // Contract.Ensures(Contract.Result<Task>().Status != TaskStatus.Created); 
        }
    }
    public class FooContractFailTaskResult : IFoo
    {
        public async Task<int> MethodAsync(int val)
        {
            await Task.Delay(val).ConfigureAwait(false);
            return val + 1;
            // esnure raises exception // Contract.Ensures(Contract.Result<int>() == val);
        }
    }
    public class Foo : IFoo
    {
        public async Task<int> MethodAsync(int val)
        {
            const int maxDeapth = 9;
            await Task.Delay(val).ConfigureAwait(false);
            if (val < maxDeapth)
            {
                await MethodAsync(val + 1).ConfigureAwait(false);
            }
            return val;
        }
    }
