     public interface IBlah
    {
        void Delete(int x);
        int Add(int x, int y);
        int Subtract(int x, int y);
    }
    public class Something
    {
        private readonly IBlah _blah;
        public Something(IBlah blah) { _blah = blah; }
        public void DoSomething(int x, int y )
        {
          //  _blah.Add(x, y);
            _blah.Subtract(x, y);
        }
    }
