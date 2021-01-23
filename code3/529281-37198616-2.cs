        public int PayOut(int Winner)
        {
            // the parameter is the winner of the race. If the dog won, return the amount bet.
            // otherwise return nothing
            if (Winner == Dog)
            {
                int payout = Amount*2;
                return payout;
            }
            else
            {
                int payout = 0;
                return payout;
            }        
        }
