        public class MyInj : ConventionInjection
        {
            protected override bool Match(ConventionInfo c)
            {
                return c.TargetProp.Name == c.SourceProp.Name 
                && c.TargetProp.Type == typeof (string) 
                && c.SourceProp.Type == typeof (List<ResourceLocalization>);
            }
            protected override object SetValue(ConventionInfo c)
            {
                return ((List<ResourceLocalization>) c.SourceProp.Value).First().Value;
            }
        }
