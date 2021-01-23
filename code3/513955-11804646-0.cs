    class SomeWidget
    {
        private static Random rng ;
        static SomeWidget()
        {
            rng = new Random() ;
            return ;
        }
        public SomeWidget()
        {
            return ;
        }
        public int DoOneThing90PercentOfTheTimeAndSomethingElseTheRestOfTheTime()
        {
            int rc ;
            int n = rng.Next() % 10 ; // get a number in the range 0 - 9 inclusive.
            if ( n != 0  ) // compare to whatever value you wish: 0, 1, 2, 3, 4, 5, 6, 8 or 9. It makes no nevermind
            {
                 rc = TheNinetyPercentSolution() ;
            }
            else
            {
                rc = TheTenPercentSolution() ;
            }
            return rc ;
        }
        private int TheTenPercentSolution()
        {
            int rc ;
            int n = rng.Next() % 2 ;
            if ( n == 0 )
            {
                rc = DoOneThing() ;
            }
            else
            {
                rc = DoAnotherThing() ;
            }
            return rc ;
        }
        private int DoOneThing()
        {
            return 1;
        }
        private int DoAnotherThing()
        {
            return 2 ;
        }
        private int TheNinetyPercentSolution()
        {
            return 3 ;
        }
    }
