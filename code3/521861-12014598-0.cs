     public class Rule<T>
        {
            public Func<T, bool> ValidationRule { get; }
            public bool IsBroken<T>(T value)
            {
                return ValidationRule(value);
            }
        }
