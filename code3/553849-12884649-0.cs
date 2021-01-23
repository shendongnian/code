        class Teams
    {
        private int[] A_Side;
        private int[] B_Side;
        public int[,] PlayingCounter;
        public int RoundCounter = 1;
        public bool DummyTeam = false;                 // ODD number of teams -> one team will no be able to play.
        
        public bool NextRoundExists
        {
            get
            {
                return (RoundCounter < B_Side.Length-1);
            }
        }
        public Teams(int NumberOfTeams)
        {
            if (NumberOfTeams % 2 != 0)
            {
                NumberOfTeams++; DummyTeam = true;
            }
            A_Side = new int[NumberOfTeams];
            B_Side = new int[NumberOfTeams];
            PlayingCounter = new int[NumberOfTeams,NumberOfTeams];     // Counting to see if alg is correct
            int x,y;
            for (x=0; x<NumberOfTeams; x++) 
            {
                A_Side[x] = x + 1;                  
                B_Side[NumberOfTeams-x-1]=x+1; 
                for (y=0;y<NumberOfTeams;y++) 
                {
                    PlayingCounter[x,y] = 0;
                }
            }
        }
        private void rotate_A_Side(int AtPos)
        {
            if (AtPos == 1)
            {
                int iO = A_Side[A_Side.Length - 1];
                rotate_A_Side(AtPos+1);
                A_Side[1] = iO;
            }
            else 
            {
                if (AtPos < A_Side.Length - 1) { rotate_A_Side(AtPos + 1); }
                A_Side[AtPos] = A_Side[AtPos - 1];
            }
        }
        public void rotate_B_Side()
        {
            int i;
            for (i = 0; i<B_Side.Length/2 ; i++)
            {
                B_Side[i] = B_Side[i + 1];
            }
            for (i = B_Side.Length / 2; i < B_Side.Length; i++)
            {
                B_Side[i] = A_Side[B_Side.Length/2 - (i -B_Side.Length/2 + 1) ];
            }
        }
        public bool NextRound()
        {
            if (NextRoundExists)
            {
                RoundCounter++;         // Next round
                rotate_A_Side(1);       // A side rotation
                rotate_B_Side();        // B side rotation
                LogRound();             // Update counters
                return true;
            }
            else return false;
        }
        public void LogRound()
        {
            for (int x = 0; x < A_Side.Length; x++)
            {
                PlayingCounter[A_Side[x]-1, B_Side[x]-1]++;
                PlayingCounter[B_Side[x]-1, A_Side[x]-1]++;
            }
        }
        public string GetCounters()
        {
            string return_value = "";
            for (int y = 0; y < A_Side.Length; y++)
            {
                for (int x = 0; x < A_Side.Length; x++)
                {
                    return_value += String.Format(" {0:D3}", PlayingCounter[y, x]);
                }
                return_value += System.Environment.NewLine;
            }
            return return_value;
        }
        public string GetCurrentRound()
        {
            string Round = "Round #" + RoundCounter.ToString() + " ";
            for (int x = 0; x < B_Side.Length; x++)
            {
                Round += String.Format("Team {0} - Team {1};", A_Side[x], B_Side[x]);
            }
            return Round;
        }
    }
