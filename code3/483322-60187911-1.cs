    public class OuPrincipalSearchFilter : AdvancedFilters
        {
            public OuPrincipalSearchFilter(Principal p) : base(p){}    
            public void testState(string value)
            {
                this.AdvancedFilterSet("st", value, typeof(string), MatchType.Equals);
            }
        }
