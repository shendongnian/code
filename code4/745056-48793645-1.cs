        public class MyCollection<T>
        {
            private T[] vector = new T[1000];
            private int actualIndex;
        
            public void Add(T elemento)
            {
                this.vector[vector.Length] = elemento;
            }
            public IEnumerable<T> CreateEnumerable()
            {
              for (int index = 0; index < vector.Length; index++)
              {
                yield return vector[(index + actualIndex)];
              }
           }
       }
