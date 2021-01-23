    using BaseSpace;
    using snEnum = Outer.SameName;          // this helps you (a using alias)
    namespace Outer.Inner
    {
      public class Tester : TesterBase
      {
        void Method2() {
          snEnum test = snEnum.Value;
        }
      }
    }
