    public class Request
    {
        public int TypeId { get; set; }
        public bool IsApproved { get; set; }
    
        public Request(int typeId)
        {
            this.TypeId = typeId;
            this.IsApproved = typeId != 1;
        }
    }
