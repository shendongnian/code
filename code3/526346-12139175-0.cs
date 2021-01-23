            int numbA;
            int[] chosenA = new int[8];
            for (int i = 0; i < 8; i++)
            {
                numbA = r.Next(9);
                for (int b = 0; b < 8; b++)
                {
                    while (chosenA.Contains(numbA) == true)
                    {
                        numbA = r.Next(9);
                        b = 0;
                    }
                }
                chosenA[i] = numbA;
            }
