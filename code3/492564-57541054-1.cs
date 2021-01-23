    public class EventInfo
    {
        [MySqlColName("ID")]
        public int EventID { get; set; }
        //Notice there is no attribute on this property? 
        public string Name { get; set; }
        [MySqlColName("State")]
        public string State { get; set; }
        [MySqlColName("Start_Date")]
        public DateTime StartDate { get; set; }
        
        [MySqlColName("End_Date")]
        public DateTime EndDate { get; set; }
    }
