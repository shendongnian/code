    namespace Mine.SuperFun
    {
        public class My { public int a; }
    }
    
    namespace SuperFun
    {
        public class Theirs { public int a; }
    }
    
    namespace SomeProgram
    {
        public class Program
        {
            SuperFun.Theirs theirs;
            global::Mine.SuperFun.My mine;
        }
    }
