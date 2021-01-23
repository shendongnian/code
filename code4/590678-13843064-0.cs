    public interface IValidatable
    {
        bool ValidateObject();
    }
    public static class ValidateExtensions
    {
        public static bool ValidateAll(this IValidatable item)
        {
            if (!item.ValidateObject())
                return false;
            const BindingFlags flags = BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public;
            var type = item.GetType();
            var props = type.GetProperties(flags).Select(x => x.GetValue(item));
            var fields = type.GetFields(flags).Select(x => x.GetValue(item));
            return props
                .Concat(fields)
                .OfType<IValidatable>()
                .Select(x => x.ValidateAll())
                .All(x => x);
        }
    }
