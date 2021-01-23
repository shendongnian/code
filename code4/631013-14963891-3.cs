    class Program {
        static void Main(string[] args) {
            IsEmptyString(NonNull.Create("abc")); //false
            IsEmptyString(NonNull.Create("")); //true
            IsEmptyString(null); //won't compile
            IsEmptyString(NonNull.Create<string>(null)); //ArgumentNullException 
            IsEmptyString(new NonNull<string>()); //bypassing, still ArgumentNullException
        }
        static bool IsEmptyString(NonNull<string> s) {
            return StringComparer.Ordinal.Equals(s, "");
        }
    }
