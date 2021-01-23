    public class Program
    {
        private class Foo
        {
            public event EventHandler FooChanged;
            ~Foo()
            {
                Console.WriteLine("Foo was collected");
            }
            public void Bar()
            {
                FooChanged += UpdateUI;
            }
            private void UpdateUI(object sender, EventArgs e)
            {
            }
        }
        public static void Main(string[] args)
        {
            var foo = new Foo();
            foo.Bar();
            foo = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("End of program");
            Console.ReadKey();
        }
    }
