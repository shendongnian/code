    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        class Item
        {
            public int Id;
            public int PalletId;
            public override string ToString()
            {
                return string.Format("{0}, {1}", Id, PalletId);
            }
        }
        class Program
        {
            void run()
            {
                var items = new []
                {
                    new Item { Id = 1, PalletId = 5},
                    new Item { Id = 2, PalletId = 6},
                    new Item { Id = 3, PalletId = 4},
                    new Item { Id = 4, PalletId = 5},
                    new Item { Id = 5, PalletId = 6},
                    new Item { Id = 6, PalletId = 4}
                };
                sortItems(items);
                items.Print();
            }
            void sortItems(Item[] items)
            {
                for (int i = 0, j = 1; i < items.Length && j < items.Length; i = j, j = i + 1)
                {
                    while ((j < items.Length) && (items[i].PalletId == items[j].PalletId))
                        ++j;
                    for (int k = j+1; k < items.Length; ++k)
                    {
                        if (items[k].PalletId == items[i].PalletId)
                        {
                            move(items, j, k);
                            break;
                        }
                    }
                }
            }
            void move(Item[] items, int to, int from)
            {
                var temp = items[from];
                for (int i = from; i > to; --i)
                    items[i] = items[i-1];
                items[to] = temp;
            }
            static void Main()
            {
                new Program().run();
            }
        }
        static class DemoUtil
        {
            public static void Print(this object self)
            {
                Console.WriteLine(self);
            }
            public static void Print(this string self)
            {
                Console.WriteLine(self);
            }
            public static void Print<T>(this IEnumerable<T> self)
            {
                foreach (var item in self) Console.WriteLine(item);
            }
        }
    }
                                                                              
