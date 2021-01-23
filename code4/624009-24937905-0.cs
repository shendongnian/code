    public static void Bubble()
        {
            int[] data = { 5, 4, 3, 2, 1 };
            bool newLoopNeeded = false;
            int temp;
            int loop = 0;
            while (!newLoopNeeded)
            {
                newLoopNeeded = true;
                for (int i = 0; i < data.Length - 1; i++)
                {
                    if (data[i + 1] < data[i])
                    {
                        temp = data[i];
                        data[i] = data[i + 1];
                        data[i + 1] = temp;
                        newLoopNeeded = false;
                    }
                    loop++;
                }
            }
        }
