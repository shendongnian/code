    public class Database
    {
        public static IEnumerable<T> ReadList<T>(IDataReader dr, Func<T> Create)
            where T : ICanRead
        {
            while (dr.Read())
            {
                T newOne = Create();
                newOne.ReadOne(dr);
                yield return newOne;
            }
        }
        public static void PopulateList<T>(List<T> list, IDataReader dr)
               where T : ICanRead, new()
        {
            list.AddRange(ReadList(dr, () => new T()));
        }
    }
