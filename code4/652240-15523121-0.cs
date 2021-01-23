        public byte[] ToByteArray(float[,] nmbs)
        {
            byte[] nmbsBytes = new byte[nmbs.GetLength(0) * nmbs.GetLength(1)*4];
            int k = 0;
            for (int i = 0; i < nmbs.GetLength(0); i++)
            {
                for (int j = 0; j < nmbs.GetLength(1); j++)
                {
                    byte[] array = BitConverter.GetBytes(nmbs[i, j]);
                    for (int m = 0; m < array.Length; m++)
                    {
                        nmbsBytes[k++] = array[m];
                    }
                }
            }
            return nmbsBytes;
        }
