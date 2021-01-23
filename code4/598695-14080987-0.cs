    public class cTicketDetail
    {
        // The default parameterless constructor is required if you want
        // to use this type as an action argument
        public cTicketDetail()
        {
        }
    
        public cTicketDetail(int id, string username)
        {
            this.Id = id;
            this.UserName = username;
        }
    
        public int Id { get; set; }
        public string UserName { get; set; }
    }
