       public interface IMerge<out T>
    {
        IEnumerable<IMergeMatched<T>> Matched();
        IEnumerable<IMergeMatched<T>> Matched(Func<T, T, bool> predicate);
        IEnumerable<T> NotMatchedBySource();
        IEnumerable<T> NotMatchedBySource(Func<T, bool> predicate);
        IEnumerable<T> NotMatchedByTarget();
        IEnumerable<T> NotMatchedByTarget(Func<T, bool> predicate);
    }
    public interface IMergeMatched<out T>
    {
        T Source { get; }
        T Target { get; }
    }
    public static class Enumerable
    {
        public static IMerge<TSource> Merge<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> target,
                                                 Func<TSource, TSource, bool> predicate)
        {
            return new Merge<TSource>(source, target, predicate);
        }
    }
    public class Merge<T> : IMerge<T>
    {
        private readonly Func<T, T, bool> _predicate;
        private readonly IEnumerable<T> _source;
        private readonly IEnumerable<T> _target;
        private IEnumerable<IMergeMatched<T>> _matcheds;
        private IEnumerable<T> _notMatchedBySource;
        private IEnumerable<T> _notMatchedByTarget;
        public Merge(IEnumerable<T> source, IEnumerable<T> taget, Func<T, T, bool> predicate)
        {
            _source = source;
            _target = taget;
            _predicate = predicate;
        }
        public IEnumerable<IMergeMatched<T>> Matched()
        {
            if (_matcheds == null)
            {
                Analize();
            }
            return _matcheds;
        }
        public IEnumerable<IMergeMatched<T>> Matched(Func<T, T, bool> predicate)
        {
            return Matched()
                .Where(t => predicate.Invoke(t.Source, t.Target))
                .ToArray();
        }
        public IEnumerable<T> NotMatchedBySource()
        {
            if (_notMatchedBySource == null)
            {
                Analize();
            }
            return _notMatchedBySource;
        }
        public IEnumerable<T> NotMatchedBySource(Func<T, bool> predicate)
        {
            return NotMatchedBySource()
                .Where(predicate)
                .ToArray();
        }
        public IEnumerable<T> NotMatchedByTarget()
        {
            if (_notMatchedByTarget == null)
            {
                Analize();
            }
            return _notMatchedByTarget;
        }
        public IEnumerable<T> NotMatchedByTarget(Func<T, bool> predicate)
        {
            return NotMatchedByTarget()
                .Where(predicate)
                .ToArray();
        }
        private void Analize()
        {
            var macheds = new List<MergeMached<T>>();
            var notMachedBySource = new List<T>(_source);
            var notMachedByTarget = new List<T>(_target);
            foreach (var source in _source)
            {
                foreach (var target in _target)
                {
                    var macth = _predicate.Invoke(source, target);
                    if (!macth) continue;
                    macheds.Add(new MergeMached<T>(source, target));
                    notMachedBySource.Remove(source);
                    notMachedByTarget.Remove(target);
                }
            }
            _matcheds = macheds.ToArray();
            _notMatchedBySource = notMachedBySource.ToArray();
            _notMatchedByTarget = notMachedByTarget.ToArray();
        }
    }
    public class MergeMached<T> : IMergeMatched<T>
    {
        public MergeMached(T source, T target)
        {
            Source = source;
            Target = target;
        }
        public T Source { get; private set; }
        public T Target { get; private set; }
    }
