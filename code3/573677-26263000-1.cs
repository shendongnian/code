    public class Appointment
    {
        public List<AppointmentRevision> Revisions { get; set; }
     
        [JsonIgnore]   
        public AppointmentRevision CurrentRevision
        {
            get { return Revision.LastOrDefault(); }
        }
    
        public Appointment()
        {
            Revisions = new List<AppointmentRevision>();
        }
    }
