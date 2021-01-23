    public class Program
    {
        public static void Main()
        {
            myList<int> lst = new myList<int>();
            lst.addItem(10);
            lst.addItem(20);
            lst.addItem(30);
            foreach (var i in lst.getItems())
            {
                Console.WriteLine(i);
            }
            lst.removeItem(20);
            foreach (var i in lst.getItems())
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
    public class myList <T>
    {
        private T[] items = new T[0];
        public void addItem(T item)
        {
            Array.Resize(ref items, items.Count() + 1);
            items[items.Count()-1] = item;
        }
        public void removeItem(T item)
        {
            Array.Resize(ref items, items.Count() -1);
        }
        public IEnumerable<T> getItems()
        {
            return items;
        }
    }
