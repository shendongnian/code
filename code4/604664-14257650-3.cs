            public static void Main(string[] args)
            {
                List<string> A = new List<string> { "Personal", "Tech" };
                List<string> B = new List<string> { "Personal", "Tech", "General"};
    
                var result = B.Except(A);
    
                foreach ( var i in result )
                {
                    Console.WriteLine(i);
                }
            }
