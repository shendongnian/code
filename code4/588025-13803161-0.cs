    public class MyAdvancedFilters : AdvancedFilters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyAdvancedFilters"/> class.
        /// </summary>
        /// <param name="principal">The source <see cref="Principal"/></param>
        public MyAdvancedFilters(Principal principal) : base(principal) { }
    
        public void WhereCompanyNotSet()
        {
            this.AdvancedFilterSet("company", "*", typeof(string), MatchType.NotEquals);
        }
    }
