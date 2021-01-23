    public sealed class Nothing {
       private Nothing() { }
       private readonly static Nothing atAll = new Nothing();
       public static Nothing AtAll { get { return atAll; } }
    }
