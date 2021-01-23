    // campaign object class, and it's separate validator logic
    public class Campaign
    {
    }
    public class CampaignValidator : IValidationStrategy<Campaign>
    {
        public bool IsValid(Campaign test)
        {
            return true;
        }
    }
    // framework stuff
    public interface IValidationStrategy<T>
    {
        bool IsValid(T test);
    }
    public static class ValidationFactory
    {
        private readonly static Dictionary<Type, object> _typeValidators;
        static ValidationFactory()
        {
            _typeValidators = new Dictionary<Type, object>();
            _typeValidators[typeof(Campaign)] = new CampaignValidator();
        }
        public static bool IsValid<T>(T obj)
        {
            return ((IValidationStrategy<T>)_typeValidators[typeof(T)]).IsValid(obj);
        }
    }
