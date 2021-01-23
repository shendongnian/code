        static void Main(string[] args)
        {
            var cache = new LruCache(3);
            cache.Put(1, 1);
            cache.Put(2, 2);
            Console.WriteLine(cache.Get(1));       // returns 1
            cache.Put(3, 3);    // evicts key 2
            Console.WriteLine(cache.Get(2));       // returns -1 (not found)
            cache.Put(4, 4);    // evicts key 1
            Console.WriteLine(cache.Get(1));       // returns -1 (not found)
            Console.WriteLine(cache.Get(3));       // returns 3
            Console.WriteLine(cache.Get(4));       // returns 4     
        }
        public class DoubleLinkedList
        {
            public int key;
            public int value;
            public DoubleLinkedList next;
            public DoubleLinkedList prev;
            public DoubleLinkedList(int k, int v)
            {
                key = k;
                value = v;
            }
        }
        public class LruCache
        {
            private int size;
            private int capacity;
            private Dictionary<int, DoubleLinkedList> map;
            private DoubleLinkedList head;
            private DoubleLinkedList tail;
            public LruCache(int cap)
            {
                capacity = cap;
                map = new Dictionary<int, DoubleLinkedList>();
                head = new DoubleLinkedList(0, 0);
                tail = new DoubleLinkedList(0, 0);
                head.next = tail;
                tail.prev = head;
            }
            public int Get(int key)
            {
                if (map.ContainsKey(key))
                {
                    if (tail.prev.key != key)
                    {
                        var node = map[key];
                        RemoveNode(node);
                        AddToEnd(node);
                    }
                    return map[key].value;
                }
                return -1;
            }
            private void AddToEnd(DoubleLinkedList node)
            {
                var beforeTail = tail.prev;
                node.prev = beforeTail;
                beforeTail.next = node;
                tail.prev = node;
                node.next = tail;
            }
            private void RemoveNode(DoubleLinkedList node)
            {
                var before = node.prev;
                before.next = node.next;
                node.next.prev = before;
            }
            public void Put(int key, int value)
            {
                if (map.ContainsKey(key))
                {
                    map[key].value = value;
                    var node = map[key];
                    RemoveNode(node);
                    AddToEnd(node);
                }
                else
                {
                    size++;
                    if (size > capacity)
                    {
                        var node = head.next;
                        RemoveNode(node);
                        map.Remove(node.key);
                        size--;
                    }
                    var newNode = new DoubleLinkedList(key, value);
                    AddToEnd(newNode);
                    map.Add(key, newNode);
                }
            }
        }
