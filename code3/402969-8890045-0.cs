    [Flags]
    public enum Foos {
        A = 1,
        B = 2,
        C = 4,
        D = 8,
        AB = A | B,
        CD = C | D,
        All = AB | CD
    }
     
    static class Program {
        static void Main() {
            Foos value = Foos.AB;
            Console.WriteLine(ClearFlag(value,Foos.A);
        }
        public static Foos ClearFlag(Foos value, Foos flag) {
           return value & ~flag;
        }
    }
