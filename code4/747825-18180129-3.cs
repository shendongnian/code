    public class CodeDetailsList
    {
        public static readonly CodeDetailsList Instance = new CodeDetailsList();
        public List<CodeDetails> ListCodeDetails { get; private set; }
        private CodeDetailsList()
        {
            ListCodeDetails = new List<CodeDetails>
           {
               new CodeDetails { Id = 1, Code = 1, Details = "xxxxx", Message = "xxxxx"},
               new CodeDetails { Id = 2, Code = 2, Details = "yyyyy", Message = "yyyy"} // ...
           };
        }
    }
