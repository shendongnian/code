    public class Status
    {
       // whatever you have here...
    }
    // essentially create a duplicate class
    public class DerivedStatus : Status { }
    // using modelBuilder...
    modelBuilder.ComplexType<Status>();
    modelBuilder.EntitySet<DerivedStatus>("Statuses");
