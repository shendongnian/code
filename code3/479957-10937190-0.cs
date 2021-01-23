       class Program {
            static IEnumerable<int> Foo() {
                int c = 0;
                while (true) {
                    c++;
                    yield return c;
                }
            }
            static void Main(string[] args) {
                var x = Foo().GetEnumerator();
                Console.WriteLine(x.Current); //0            
                x.MoveNext();
                Console.WriteLine(x.Current); //1
                x.MoveNext();
                Console.WriteLine(x.Current); //2
                Console.ReadLine();
            }
        }
