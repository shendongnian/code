            public static void Main(string[] args)
            {
                List<string> A = new List<string> { "Personal", "Tech", "Social" };
                List<string> B = new List<string> { "Personal", "Tech", "General" };
    
                var result = A.Except(B);
    
                //Will print "Social"
                foreach (var i in result)
                {
                    Console.WriteLine(i);
                }
            }
