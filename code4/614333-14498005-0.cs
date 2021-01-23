    public interface A { }
    public interface B<T> where T : A
    {
        List<T> a { get; set; }
    }
    public interface BA : B<A>
    { 
    }
    public interface C<T> where T : BA
    {
        List<T> b { get; set; } // << ERROR: Using the generic type 'B<T>' requires 1 type arguments
    }
