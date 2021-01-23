    IAsyncOperation<MyResult> MyMethod();
}
    public sealed class MyClass: IMyInterface
    {
        private async Task<MyResult> MyMethodAsync()
        {
            var r = await TryGetAuthResultFromFileAsync();
            if (r != null)
                return r;
            return await GetAuthResultFromAuthenticationBrokerAsync();
        }
    
        public IAsyncOperation<MyResult> MyMethod()
        {
            return MyMethodAsync().AsAsyncOperation();
        }
    }
