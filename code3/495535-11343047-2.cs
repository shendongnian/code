    public class Blah : ISomeInterface
    {
        public ISomeInterface i { getter and setter here }
        public int ISomeInterface.DoThis() { if (i) return i.DoThis(); }
        public void ISomeInterface.DoThat(int param) { if (i) i.DoThat(param); }
    etc...
