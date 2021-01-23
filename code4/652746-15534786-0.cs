    class Base
    {
        private int x;
        private class Derived : Base
        {
            private void M()
            {
                Console.WriteLine(this.x); // legal!
            }
        }
    }
