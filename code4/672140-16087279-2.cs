    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var myContainer = new Container<string>();
    
                myContainer.MyItems = new List<Item<string>>();
            }
        }
    
        public class Item<T> { }
    
        public class Container<T>
        {
            // Just some property on your container to show you can use Item<T>
            public List<Item<T>> MyItems { get; set; }
        }
    }
