    public class ViewFilterSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(ViewFilterCollection), AddItemName = "ViewFilter")]
        private ViewFilterCollection ViewFilterCollection
        {
            get { return (ViewFilterCollection)this[string.Empty]; }
            set { this[string.Empty] = value; }
        }
        public static List<ViewFilterElement> ViewFilters
        {
            get
            {
                ViewFilterSection sec = (ViewFilterSection)ConfigurationManager.GetSection("ViewFilterGroup");
                return sec.ViewFilterCollection.As<ViewFilterElement>().ToList();
            }
        }
    }
