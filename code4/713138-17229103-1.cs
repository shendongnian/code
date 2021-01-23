    public partial class DocMgmtDataContext :DbContext
    {
        public DocMgmtDataContext()
            : base(ConfigurationManager.ConnectionStrings["ProjectS"].ConnectionString)
        {
            OnCreated();
        }
    }
