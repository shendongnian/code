    public class NutritionalEvaluation
    {
        [ScaffoldColumn (false)]
        public virtual int ID { get; set; }
        
        // This is the name of the navigation property defined below
        [ForeignKey("PatientAppointment")]
        public virtual int AppointmentID { get; set; }
        
        public virtual int KiloCal { get; set; }
        public virtual int Proteines { get; set; }
        public virtual int Carbs { get; set; }
        public virtual int Fiber { get; set; }
        public virtual int Fats { get; set; }
        public virtual int Cholesterol { get; set; }
        public virtual int Water { get; set; }
        public virtual int Alcohol { get; set; }
        // Add navigation property to PatientAppointment
        public virtual PatientAppointment PatientAppointment { get; set; }
    }
