    public class YourClass : IEnumerable
    {
        // ...
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Rows; i++)
            {
                Field[] result = new Field[Columns];
                for (int j = 0; j < Columns; j++)
                {
                    result[j] = this[i, j];
                }
                yield return result;
            }
        }
    }
