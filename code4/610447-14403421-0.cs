        public class YourDataClass {
            public string RequestDate { get; set; }
            public string NotifDate { get; set; }
            .
            .
            .
        }
        public class Sorter<T> where T : YourDataClass {
            private Dictionary<string, Func<T, T, int>> actions =
                new Dictionary<string, Func<T, T, int>> {
                    {"reqDate", (x, y) => String.Compare(x.RequestDate, y.RequestDate)},
                    {"notifDate", (x, y) => String.Compare(x.NotifDate, y.NotifDate)}
                };
            public IEnumerable<T> Sort(IEnumerable<T> list, string howTo) {
                var items = list.ToArray();
                Array.Sort(items, (x, y) => actions[howTo](x, y));
                return items;
            }
        }
        public void Sample() {
            var list = new List<YourDataClass>();
            var sorter = new Sorter<YourDataClass>();
            var sortedItems = sorter.Sort(list, "reqDate");
        }
