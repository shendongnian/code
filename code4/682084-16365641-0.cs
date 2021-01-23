        [TestMethod]
        public void GenericTest()
        {
            object[,] array = new object[9, 2];
            for (int i = 0; i <= 8; i++)
            {
                array[i, 0] = i;
                array[i, 1] = i * 2;
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int k = 0; k < array.GetLength(1); k++)
                {
                    Console.Write(array[i,k]+" ");
                }
                Console.WriteLine();
            }
        }
