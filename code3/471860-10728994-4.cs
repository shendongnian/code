    public abstract class DerivedE<T> : Base<DerivedE<T>> where T : DerivedE<T>
    {
    }
    public class DerivedF : DerivedE<DerivedF>
    {
    }
    public class DerivedG : DerivedE<DerivedG>
    {
    }
    new DerivedF().Changed(new DerivedG()); // does not compile
    new DerivedF().Changed(new DerivedF()); // does compile
