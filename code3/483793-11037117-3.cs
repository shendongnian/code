    public static class EnumerableEx {
        public static void Paginate<T>(this IEnumerable<T> elements, int page_size, Action<IEnumerable<T>> process_page) {
            var buff = new T[3];
            int index = 0;
            foreach (var element in elements) {
                if (index == buff.Length) {
                    process_page(buff);
                    index = 0;
                }
                buff[index++] = element;
            }
            if (index > 0)
                process_page(buff.Take(index));
        }
        
    }
    // ...
    var _Records = Enumerable.Range(1, 16).ToArray();
    _Records.Paginate(3, Process);
