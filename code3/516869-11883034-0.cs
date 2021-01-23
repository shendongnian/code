    public class Request
    {
        public int TypeId { get; set; }
        public bool IsApproved 
        { 
            get
            {
                return this.TypeId == 2;
            }
    }
