    public static class PartitionExtensions
    {
        public static IEnumerable<IPartition<T>> ToPartition<T>(this IEnumerable<T> source, int partitionCount)
        {
            if (source == null)
            {
                throw new NullReferenceException("source");
            }
            return source.Select((item, index) => new { Value = item, Index = index })
                         .GroupBy(item => item.Index % partitionCount)
                         .Select(group => new Partition<T>(group.Key, group.Select(item => item.Value)));
        }
    }
    public interface IPartition<out T> : IEnumerable<T>
    {
        int Index { get; }
    }
    public class Partition<T> : IPartition<T>
    {
        private readonly IEnumerable<T> _values;
        public Partition(int index, IEnumerable<T> values)
        {
            Index = index;
            _values = values;
        }
        public int Index { get; private set; }
        public IEnumerator<T> GetEnumerator()
        {
            return _values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
