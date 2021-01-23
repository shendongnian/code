    abstract class A
    {
        public abstract string F();
        protected static string S()
        {
            var st = new StackTrace();
            return st.GetFrame(1).GetMethod().DeclaringType.Name;
        }
    }
    class B : A
    {
        public override string F()
        {
            return S(); // returns "B"
        }
    }
    class C : A
    {
        public override string F()
        {
            return S();  // returns "C"
        }
    }
