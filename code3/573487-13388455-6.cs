    //this is just a marker interface. don't directly imeplement this.
    interface IRule
    {
    }
    interface IRule<T> : IRule
    {
        bool IsBroken(T model);
        ErrorMessage Message {get;}
    }
    class RulesEngine : IRulesEngine
    {
        public reasdonly ICollection<IRule> Rules = new List<IRule>();
        public IEnumerable<ErrorMessage> Validate<T>(T model)
        {
           return Rules
                     .Where(x => typeof(IRule<T>).IsAssignableFrom(x.GetType()))
                     .Cast<IRule<T>>()
                     .Where(rule => rule.IsBroken(model))
                     .Select(rule =>  rule.Message);
        }
    }
