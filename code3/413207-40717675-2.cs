    [ContractClass(typeof(ContractClassForIFoo))]
    public interface IFoo
    {
        Task<object> MethodAsync();
    }
    [ContractClassFor(typeof(IFoo))]
    internal abstract class ContractClassForIFoo : IFoo
    {
        #region Implementation of IFoo
        public Task<object> MethodAsync()
        {
            Contract.Ensures(Contract.Result<Task<object>>() != null);
            Contract.Ensures(Contract.Result<Task<object>>().Status != TaskStatus.Created);
            Contract.Ensures(Contract.Result<object>() != null);
            throw new NotImplementedException();
        }
        #endregion
    }
    public class Foo : IFoo
    {
        public async Task<object> MethodAsync()
        {
            var result = await Task.FromResult(new object());
            return result;
        }
    }
