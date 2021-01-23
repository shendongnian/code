    public abstract class LocalizationStringInjection<TSource, TTarget> : LoopValueInjectionBase
    {
        public ILocalizationContext LocalizationContext { get; set; }
        protected LocalizationStringInjection(ILocalizationContext localizationContext)
        {
            LocalizationContext = localizationContext;
        }
        protected virtual bool TypesMatch(Type sourceType, Type targetType)
        {
            return sourceType == typeof(TSource) && targetType == typeof(TTarget);
        }
        protected override void Inject(object source, object target)
        {
            foreach (PropertyDescriptor targetPropertyDescriptor in target.GetProps())
            {
                var t1 = targetPropertyDescriptor;
                var es = UberFlatter.Flat(targetPropertyDescriptor.Name, source, type => TypesMatch(type, t1.PropertyType));
                var endpoint = es.FirstOrDefault();
                if (endpoint == null) continue;
                var sourceValue = endpoint.Property.GetValue(endpoint.Component) is TSource ? (TSource)endpoint.Property.GetValue(endpoint.Component) : default(TSource);
                if (AllowSetValue(sourceValue))
                    targetPropertyDescriptor.SetValue(target, SetValue(sourceValue, targetPropertyDescriptor));
            }
        }
        protected abstract TTarget SetValue(TSource sourcePropertyValue, PropertyDescriptor targetPropertyDescriptor);
    }
    public class LengthLocalizationStringInjection : LocalizationStringInjection<decimal, string>
    {
        public LengthLocalizationStringInjection(ILocalizationContext localizationContext) : base(localizationContext) { }
        protected override string SetValue(decimal sourceValue, PropertyDescriptor targetPropertyDescriptor)
        {
            var lengthHints = targetPropertyDescriptor.Attributes.Cast<object>().Where(attribute => attribute.GetType() == typeof(LengthLocalizationAttribute)).Cast<LengthLocalizationAttribute>().ToList();
            return lengthHints.Any() ? sourceValue.ToLength(lengthHints.First(l => l.SuggestedLengthType == LocalizationContext.Length).SuggestedLengthType) : sourceValue.ToLength(default(LengthType));
        }
    }
