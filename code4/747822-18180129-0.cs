    public class codeDetailsList
    {
        public static readonly Instance = new codeDetailsList();
        public List<CodeDetailst> lstCodeDetailst { get; private set; }
        private codeDetailsList()
        {
            lstCodeDetails = new List<CodeDetails>();
        }
    }
