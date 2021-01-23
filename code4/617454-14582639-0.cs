    public static class TestClass
        {
            public static string stat(string measureGroup, int rangeThreshold)
            {
                return "st1";
            }
    
            public static string stat(int startDateRange)
            {
                return "st2";
            }
    
            private testmethode()
            {
               // string h = TestClass.stat(.... at this point i get both variants offered)
            }
           
        }
