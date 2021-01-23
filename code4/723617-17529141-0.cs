    namespace Sample2
    {
        public interface IInterfaceContainer<T1, T2>            
            where T1 : T2
        { }
    
        public interface IInterfaceParent
        { }
    
        public interface IInterfaceChild : IInterfaceParent
        { }
    
        public class ClassSampleDoesNotWork<TItem>
            where TItem : class, IInterfaceParent
        {
            IInterfaceContainer<IEnumerable<TItem>, IEnumerable<IInterfaceParent>> SomeProperty { get; set; }
        }
    }
