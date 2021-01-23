    public static class EnumerableExtension
    {
        public static IEnumerable<Step<T>> StepWise<T>(this IEnumerable<T> instance)
        {
            using (IEnumerator<T> enumerator = instance.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    yield return new Step<T>(enumerator);
                }
            }
        }
    
        public struct Step<T>
        {
            private IEnumerator<T> enumerator;
    
            public Step(IEnumerator<T> enumerator)
            {
                this.enumerator = enumerator;
            }
    
            public bool MoveNext()
            {
                return enumerator.MoveNext();
            }
    
            public T Current
            {
                get { return enumerator.Current; }
            }
    
        }
    }
