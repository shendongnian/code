    class Program {
        static void Main(string[] args) {
            IsEmptyString("abc"); //false
            IsEmptyString(""); //true
            IsEmptyString(null); //ArgumentNullException
            IsEmptyString(new NonNull<string>()); //bypassing, still ArgumentNullException
        }
        static bool IsEmptyString(NonNull<string> s) {
            return StringComparer.Ordinal.Equals(s, "");
        }
    }
