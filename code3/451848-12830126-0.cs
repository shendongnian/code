    public class PeriodMapping
    {
        public static Action<ComponentPart<Period>> ForPolicy()
        {
            return c =>
            {
                c.Map(p => p.From, "CommencementDate");
                c.Map(p => p.To, "ReasonForEnding");
            };
        }
    
        public static Action<ComponentPart<Period>> ForPasswordOfUser()
        {
            return c =>
            {
                c.Map(p => p.From, "PasswordValidFrom");
                c.Map(p => p.To, "PasswordValidUntil");
            };
        }
    
        // serveral other mappings
    }
