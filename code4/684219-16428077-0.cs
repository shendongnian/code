    using System.Linq;
    public class DataTable : IEnumerable<T>
    {
        IEnumerable<T> IEnumerable<T>.GetEnumerator()
        {
            return from row in rows
                   where FindIfRowIsOfClass<T>(row)
                   select new T(row);
        }
    }
