    public class StringPropertyTruncateSpecimenBuilder<TEntity> : ISpecimenBuilder
    {
        private readonly int _length;
        private readonly PropertyInfo _prop;
        public StringPropertyTruncateSpecimenBuilder(Expression<Func<TEntity, string>> getter, int length)
        {
            _length = length;
            _prop = (PropertyInfo)((MemberExpression)getter.Body).Member;
        }
        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as PropertyInfo;
            return pi != null && AreEquivalent(pi, _prop)
                ? context.Create<string>().Substring(0, _length)
                : (object) new NoSpecimen(request);
        }
        private bool AreEquivalent(PropertyInfo a, PropertyInfo b)
        {
            return a.DeclaringType == b.DeclaringType
                   && a.Name == b.Name;
        }
    }
