        public int this[int x, int y] {
            get
            {
                return Data[x, y];
            }
            set
            {
                if (value > 21) //Only over 21's allowed in here
                {
                    Data[x, y] = value;
                }
            }
        }
