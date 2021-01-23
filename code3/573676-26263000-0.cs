    public class Appointment
    {
        public List<AppointmentRevision> Revisions { get; set; }
        
        public AppointmentRevision CurrentRevision
        {
            get { return Revision.LastOrDefault(); }
        }
    
        public Appointment()
        {
            Revisions = new List<AppointmentRevision>();
        }
    }
