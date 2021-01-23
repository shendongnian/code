    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var myContainer = new Container<StringItem>();
    
                myContainer.StronglyTypedItem = new StringItem();
            }
        }
    
        public class Item<T> { }
    
        public class StringItem : Item<string> { }
    
        // Probably a way to hide this, but can't figure it out now
        // (needs to be public because it's a base type)
        // Probably involves making a container (or 3rd class??)
        // wrap a private container, not inherit it
        public class PrivateContainer<TItem, T> where TItem : Item<T> { }
    
        // Public interface
        public class Container<T> : PrivateContainer<Item<T>, T>
        {
            // Just some property on your container to show you can use Item<T>
            public T StronglyTypedItem { get; set; }
        }
    }
