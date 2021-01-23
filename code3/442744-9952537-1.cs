    public interface ITOrU { /*empty interface*/ }
    public interface IT : ITOrU
    {
    }
    public interface IU : ITOrU
    {
    }
    class Type1<T, U>
        where T : IT
        where U : IU
    {
        public static Type1<T, U> New( ITOrU v )
        {
            return new Type1<T, U>();
        }
    }
