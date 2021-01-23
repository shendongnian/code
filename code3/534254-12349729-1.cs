    public class EmailItem { 
        
        public DateTime SentDate { get; set; }
        public string ShowEmailAsGmail { get {
        {
            DateTime now = DateTime.UtcNow;
            if (this.SentDate.Date == now.Date)
                return this.SentDate.ToString("HH:mm");
            return this.SentDate.ToString("MMM dd");
        }
    }
