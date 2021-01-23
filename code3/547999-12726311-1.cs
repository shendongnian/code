    public static class ArrayExtension
    {
        void Substitute<T>(this T[] array, IDictionary<T, T> subsitute)
        {
             for (var i = 0; i < array.Length; i++)
             {
                  if (substitute.ContainsKey(array[i])
                  {
                      array[i] = substitute[array[i]];   
                  }
             }
        } 
    }
