        public override bool Equals(object obj)
        {
            return Equals(obj as State);
        }
        public bool Equals(State s2)
        { //Overloaded equals operator 
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (grid[x, y] != s2.grid[x, y])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
