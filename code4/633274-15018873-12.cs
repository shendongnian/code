    public class Mydate {
        public string ndate { get; set; }
        public MyDateNDay[] dates { get; set; }
        public string pdate { get; set; }
    }
    public class MyDateNDay {
        public string date {get; set;}
        public string day { get; set; }
    }
    public class Mystaff
    {
        public Staff[] staff { get; set; }
    }
    public class Staff
    {
        public int StaffID { get; set; }
        public int BusinessID { get; set; }
        public TimeSlot[] slots { get; set; }
    }
    public class TimeSlot
    {
        public int SlotID { get; set; }
        public string SlotDate { get; set; }
        public string SlotDay { get; set; }
        public string SlotTime { get; set; }
    }
