    public static class AnonymousObjectMutator
    {
        private const BindingFlags FieldFlags = BindingFlags.NonPublic | BindingFlags.Instance;
        private static readonly string[] BackingFieldFormats = { "<{0}>i__Field", "<{0}>" };
        public static T Set<T, TProperty>(
            this T instance,
            Expression<Func<T, TProperty>> propExpression,
            TProperty newValue) where T : class
        {
            var pi = (propExpression.Body as MemberExpression).Member;
            var backingFieldNames = BackingFieldFormats.Select(x => string.Format(x, pi.Name)).ToList();
            var fi = typeof(T)
                .GetFields(FieldFlags)
                .FirstOrDefault(f => backingFieldNames.Contains(f.Name));
            if (fi == null)
                throw new NotSupportedException(string.Format("Cannot find backing field for {0}", pi.Name));
            fi.SetValue(instance, newValue);
            return instance;
        }
    }
