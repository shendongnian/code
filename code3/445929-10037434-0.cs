    public class Customer {
      // id, name, owner, etc
      public virtual IList<CustomerPolicy> Policies { get; set; }
    }
    public class CustomerPolicy {
      // id, name, etc
      public bool ExistingPatient { get; set; }
      public bool AgeInPatient { get; set; }
      public bool NewPatient { get; set; }
    }
