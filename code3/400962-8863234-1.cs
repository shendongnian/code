    class Program
    {
        public interface IProblem<out T>
        {
            ushort ResultCount { get; }
            T[] Results { get; }
            bool IsCorrect();
        }
        public class ProblemBase<T> : IProblem<T>
        {
            private T[] _results;
            private ushort? _resultCount;
            public ushort ResultCount
            {
                get
                {
                    if (_resultCount == null) throw new ArgumentNullException("_resultCount");
                    return (ushort)_resultCount;
                }
                protected set
                {
                    if (_resultCount != value)
                        _resultCount = value;
                }
            }
            public T[] Results
            {
                get
                {
                    if (_results == null)
                        _results = new T[ResultCount];
                    return _results;
                }
            }
            public bool IsCorrect()
            {
                return true;
            }
        }
        public interface IProblemViewModel<out T>
        {
            IProblem<T> Problem { get; }
        }
        public class BaseResult
        {
        }
        public class DerivedResult : BaseResult
        {
        }
        public class OtherResult : BaseResult
        {
        }
        public class ProblemViewModel<T> : IProblemViewModel<T>
        {
            public IProblem<T> Problem
            {
                get
                {
                    throw new NotImplementedException();
                }
                set
                {
                    throw new NotImplementedException();
                }
            }
        }
        static void Main(string[] args)
        {
            ObservableCollection<IProblemViewModel<object>> collection = new ObservableCollection<IProblemViewModel<object>>
            {
                new ProblemViewModel<DerivedResult>(),
                new ProblemViewModel<OtherResult>()
                //, new ProblemViewModel<int>()   // This is not possible, does not compile.
            };
        }
    }
