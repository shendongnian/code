        public float[,] ToFloatArray(byte [] nmbsBytes)
        {
            float[,] nmbs = new float[nmbsBytes.Length /4 / 2, 2];
            int k = 0;
            for (int i = 0; i < nmbs.GetLength(0); i++)
            {
                for (int j = 0; j < nmbs.GetLength(1); j++)
                {
                    nmbs[i, j] = BitConverter.ToSingle(nmbsBytes,k);
                    k += 4;
                }
            }
            return nmbs;
        }
