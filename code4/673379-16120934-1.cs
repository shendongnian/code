    abstract class A
    {
        public abstract string F();
        protected static string S()
        {
            var st = new StackTrace();
            // this is what you are asking for
            var callingType = st.GetFrame(1).GetMethod().DeclaringType;
            return callingType.Name;
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
