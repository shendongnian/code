    public interface A { }
    public interface B<T> where T : A
    {
        List<T> a { get; set; }
    }
    public interface C<T> where T : B<A>
    {
        List<T> b { get; set; } 
    }
