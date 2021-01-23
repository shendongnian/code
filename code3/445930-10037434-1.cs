    public enum PatientType { Existing, AgeIn, NewPatient };
    public class CustomerPolicy {
      // id, name, etc
      public PatientType PatientType { get; set; }
    }
