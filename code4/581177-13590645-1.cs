    class Foo
    {
        private string bar;
        public void Method()
        {
            if (!String.IsNullOrEmpty(bar)) // <-- No more this.
            {
                string bar1 = "Hello";
                Console.Write(bar);
            }
            if (!String.IsNullOrEmpty(bar)) // <-- No more this.
            {
                string bar1 = "Hello";
                Console.Write(bar);
            }
        }
    }
