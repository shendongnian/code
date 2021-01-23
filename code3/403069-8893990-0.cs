        //"Bad" name class
    public class IBadClass
    {
        public void SomeFuncA(int i)
        {
        }
        public void SomeFunctB(string str)
        {
        }
    }
    //"Better" name class
    public class BetterNameClass
    {
        private IBadClass _badClass;
        public BetterNameClass()
        {
            _badClass = new IBadClass();
        }
        public void SomeFuncA(int i)
        {
            _badClass.SomeFuncA(i);
        }
        public void SomeFunctB(string str)
        {
            _badClass.SomeFunctB(str);
        }
    }
