    abstract class ItemBase  { }
    class AskItem : ItemBase { }
    class BlogItem : ItemBase { }
    class ProvderA : ProviderBase<AskItem>
    {
        public override AskItem Get()
        {
            throw new NotImplementedException();
        }
    }
    class ProvderB : ProviderBase<BlogItem>
    {
        public override BlogItem Get()
        {
            throw new NotImplementedException();
        }
    }
    abstract class ProviderBase<T> where T : ItemBase
    {
        public abstract T Get();
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            ProviderBase<AskItem> provider = GetProvider<AskItem>();
            var item = provider.Get();
        }
        static ProviderBase<T> GetProvider<T>() where T : ItemBase
        {
            if (typeof(T) == typeof(AskItem))
                return (ProviderBase<T>)(object)new ProvderA();
            if (typeof(T) == typeof(BlogItem))
                return (ProviderBase<T>)(object)new ProvderB();
            return null;
        }
    }
