    public abstract class PostEvent<TPost> : IDomainEvent
        where TPost : Post, new()
    {
        protected abstract void SomeInterfaceMethod();
        void IDomainEvent.SomeInterfaceMethod() {
            SomeInterfaceMethod(); // proxy to the protected abstract version
        }
    }
