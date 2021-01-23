    public class CodeDetailsList
    {
        public static readonly Instance = new CodeDetailsList();
        public List<CodeDetails> ListCodeDetails { get; private set; }
        private CodeDetailsList()
        {
            ListCodeDetails = new List<CodeDetails>();
        }
    }
