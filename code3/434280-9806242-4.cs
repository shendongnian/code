    public class CCYDictionary : DataTableDictionary<CCYDictionary>
    {
        protected override DataTable table { get { return ((App)App.Current).ApplicationData.CCY; } }
        protected override string indexKeyField { get { return "CCY"; } }
        public CCYDictionary() { }
    }
    public class BCPerilDictionary : DataTableDictionary<BCPerilDictionary>
    {
        protected override DataTable table { get { return ((App)App.Current).ApplicationData.PerilCrossReference; } }
        protected override string indexKeyField { get { return "BCEventGroupID"; } }
        public BCPerilDictionary() { }
    }
    //etc...
