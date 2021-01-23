    public class ClientGroupDetails
    {
        // Not 100% sure what appropriate names should be here
        public DateTime Date { get; set; }
        public String Name { get; set; }
        public Int32 Id { get; set; }
        public ClientGroupDetails(DateTime date, String name, Int32 id)
        {
            this.Date = date;
            this.Name = name;
            this.Id = id;
        }
        // I also wouldn't include this unless you really need it...
        // public ClientGroupDetails() { }
    }
