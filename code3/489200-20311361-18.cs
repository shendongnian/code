        class Test : IEnumerable<int>
        {
            public SomethingEnumerator GetEnumerator()
            {
                //this one is called
            }
            IEnumerator<int> IEnumerable<int>.GetEnumerator()
            {
            }
        }
    If you don't have a public implementation (ie only explicit implementation), then precedence goes like `IEnumerator<T>` > `IEnumerator`.
