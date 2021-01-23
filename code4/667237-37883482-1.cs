    public interface IFoo
    {
        Task FooAsync();
    }
    public class FooA : IFoo
    {
        public Task FooAsync() { /* ... */ }
    }
    public class FooB : IFoo
    {
        public async Task FooAsync() { /* ... */ }
    }
