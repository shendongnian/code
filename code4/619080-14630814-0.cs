    public class A
    {
        public IEnumerator GetEnumerator()
        {
            yield return new B();
        }
    }
