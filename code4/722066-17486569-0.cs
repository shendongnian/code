    public class SmsResponse
    {
        public string AliasName { get; set; }
        public string CellPhoneNumber { get; set; }
        public int Response { get; set; }
        public override string ToString()
        {
            return AliasName + "|" + CellPhoneNumber + "|" +
                Response.ToString();
        }
    }
    
