        static int sum = 0;
        private static readonly int[,] matrix = new int[3,3];
        private static readonly Random _r = new Random();
        private static void MakeMatrix()
        {
            //by default all the element in the matrix will be zero, so setting to zero is not a issue
            // now we need to fill 3 random places with numbers between 1-3 i guess ?
            //an array of int[3] to remember which places are already used for random num
            int[] used = new int[3];
            int pos;
            for (int i = 0; i < 3; i++)
            {
                pos = _r.Next(0, 8);
                var x = Array.IndexOf(used, pos);
                while (x != -1)
                {
                    pos = _r.Next(0, 8);
                }
                used[i] = pos;
                matrix[pos/3, pos%3] = _r.Next(1, 3);
            }
        }
