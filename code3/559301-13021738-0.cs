    interface IFoo {
        Task BarAsync();
    }
    class Foo : IFoo {
        public async Task BarAsync() {
            // Implemented via async/await in this case.
            // You could also have implemented it without async/await.
        }
    }
    // ...
    async void Test() {
        IFoo foo = ... ;
        await foo.BarAsync(); // Works no matter how BarAsync is implemented.
    }
