    namespace FIT.DLLTest
    {
      public class DLLTest
      {
        [STAThread]
        static void Main(string[] args)
        {
          int a = 1;
        }
        public DLLTest()
        {
          int b = 17;
        }
        public int Add(int int1, int int2)
        {
          return int1 + int2;
        }
      }
    }
