    class Props {
        public List<object> list = new List<object>();
        public override bool Equals(object obj) {
            return (obj as Props).list.Zip(list, (o1, o2) => o1.Equals(o2)).All(b => b);
        }
        public override int GetHashCode() {
            return list.Select(o => o.GetHashCode()).Aggregate((i1, i2) => i1 ^ i2);
        }
    }
    class Program {
        static void Main(string[] args) {
            Lol db = new Lol(@"Data Source=c:\recent\lol.sdf");
            doLinq(db.Test, row => row.Col1, row => row.Col2); 
            Console.ReadLine();
        }
        static void doLinq<T>(Table<T> table, params Func<T, object>[] selectors) where T : class {
            Func<T, Props> selector = item => {
                var props = new Props();
                foreach (var sel in selectors) props.list.Add(sel(item));
                return props;
            };
            foreach (var grp in table.GroupBy(selector)) {
                Console.Write("Grouping by " + string.Join(", ", grp.Key.list) + ": ");
                Console.WriteLine(grp.Count() + " rows");
            }
        }
    }
