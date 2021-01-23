    public class CodeDetailsList
    {
        private static readonly CodeDetailsList _instance = new CodeDetailsList();
        public static CodeDetailsList Instance 
        {
            get { return _instance; }
        }
    
        public ReadOnlyCollection<CodeDetails> lstCodeDetailst { get; private set; }
    
        private codeDetailsList()
        {
            var masterList = new List<CodeDetails>();
    
            masterList.Add(new CodeDetails(1, 111, "xxxxx", "xxxxxxxxxxx"));
            masterList.Add(new CodeDetails(2, 222, "yyyyy", "yyyyyyyyyyy"));
            //... And so on ...
    
            //mark the list as read only so no one can add/remove/replace items in the list
            lstCodeDetailst= masterList.AsReadOnly();
        }
    }
    public class CodeDetails
    {
       public CodeDetails(id, code, message, details)
       {
           Id = id;
           Code = code;
           Message = message;
           Details = details;
       }
       //Mark the setters private so no one can change the values once set.
       public int Id { get; private set; }
       public int Code { get; private set; }
       public string Message { get; private set; }
       public string Details { get; private set; }
    }
