    public class NoNullsInjection : ConventionInjection
    {
        protected override bool Match(ConventionInfo c)
        {
            return c.SourceProp.Name == c.TargetProp.Name
                    && c.SourceProp.Value != null;
        }
    }
