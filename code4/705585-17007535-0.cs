    public class Generics<T>
    {
        public T Member;
    
        public String ErrorMessage;
    
        public Generics(T member)
        {
            this.Member = member;
        }
    
        private Generics()
        {
            // empty constructor just to allow the class to create itself internally
        }
        public static Generics FromError(String errorMessage)
        {
            return new Generics { ErrorMessage = errorMessage };
        }
    }
