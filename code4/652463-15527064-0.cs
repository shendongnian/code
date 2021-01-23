    class Program {
        static void Main(string[] args) {
            List<string> data = new List<string>();
            foreach (var item in data.FailIfEmpty(new Exception("List is empty"))) {
                // do stuff
            }
        }
    }
    public static class Extensions {
        public static IEnumerable<T> FailIfEmpty<T>(this IEnumerable<T> collection, Exception exception) {
            if (!collection.Any()) {
                throw exception;
            }
            return collection;
        }
    }
