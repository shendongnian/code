    public class House
    {
        public House()
        {
          Reviews = new List<Review>();
        }
        public virtual int HouseID { get; set; }
        public virtual string postCode { get; set; }
        public virtual string address1 { get; set; }
        public virtual string address2 { get; set; }
        public virtual int noOfDisputes { get; set; } //number of disputes added by tennants
        public virtual int averageRating { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }        
    }
}
