    public class Program {
        public static void Main(String[] args) {
            List<O> L1 = new List<O>{
                new O {K = 1, V = "abcd"},
                new O {K = 2, V = "efgh"}
            };
            List<O> L2 = new List<O>{
                new O {K = 1, V = "abcd"}
            };
            List<O> L3 = new List<O>{
                new O {K = 1, V = "abcd"},
                new O {K = 3, V = "ijkl"}
            };
            List<O> L4 = new List<O>{
                new O {K = 2, V = "efgh"},
                new O {K = 1, V = "abcd"}
                
            };
            Console.WriteLine(L1.Select(x => x.K).ToArray().Except(L1.Select(x => x.K).ToArray()).Count());
            Console.WriteLine(L1.Select(x => x.K).ToArray().Except(L2.Select(x => x.K).ToArray()).Count());
            Console.WriteLine(L1.Select(x => x.K).ToArray().Except(L3.Select(x => x.K).ToArray()).Count());
            Console.WriteLine(L1.Select(x => x.K).ToArray().Except(L4.Select(x => x.K).ToArray()).Count());
        }
    } 
    public class O {
        public int K { get; set; }
        public String V { get; set; }
    }
