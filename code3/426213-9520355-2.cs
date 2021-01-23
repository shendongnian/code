    public static class Range
    {
        public interface ISwitchable
        {
            void SetDefault(Action defaultStatement);
            void Execute();
        }
        
        public interface ISwitchable<T>: ISwitchable
            where T: IComparable<T>
        {
            T Value { get; set; }
            void AddCase(ICase<T> caseStatement);
        }
        public class Switchable<T> : ISwitchable<T>
            where T: IComparable<T>
        {
            private readonly IList<ICase<T>> _caseStatements = new List<ICase<T>>();
            private Action _defaultStatement;
            #region ISwitchable<T> Members
            public T Value { get; set; }
            public void AddCase(ICase<T> caseStatement)
            {
                _caseStatements.Add(caseStatement);
            }
            public void SetDefault(Action defaultStatement)
            {
                _defaultStatement = defaultStatement;
            }
            public void Execute()
            {
                foreach (var caseStatement in _caseStatements)
                    if ((caseStatement.Min.CompareTo(Value) <= 0) && (caseStatement.Max.CompareTo(Value) > 0))
                    {
                        caseStatement.Action();
                        return;
                    }
                _defaultStatement();
            }
            #endregion
        }
        public interface ICase<T>
            where T: IComparable<T>
        {
            T Min { get; set; }
            T Max { get; set; }
            Action Action { get; set; }
        }
        public sealed class Case<T>: ICase<T>
            where T: IComparable<T>
        {
            #region ICase<T> Members
            public T Min { get; set; }
            public T Max { get; set; }
            public Action Action { get; set; }
            #endregion
        }
        public static ISwitchable<T> Switch<T>(T value)
            where T: IComparable<T>
        {
            return new Switchable<T>();
        }
    }
    public static class SwitchableExtensions
    {
        public static Range.ISwitchable<T> Case<T>(this Range.ISwitchable<T> switchable, T min, T max, Action action)
            where T: IComparable<T>
        {
            switchable.AddCase(new Range.Case<T>{ Min = min, Max = max, Action = action });
            return switchable;
        }
        public static void Default(this Range.ISwitchable switchable, Action action)
        {
            switchable.SetDefault(action);
            switchable.Execute();
        }
    }
    
