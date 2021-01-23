            for (int i = 0; i < iArray.Length; i++)
            {
                int count=0;
                for (int j = i + 1; j < iArray.Length; j++)
                {
                    if (iArray[i] == iArray[j])
                    {
                        count++;
                    }
                }
                if (count==0)
                {
                    unique.Add(iArray[i]);
                }
            }
            iArray = unique.ToArray();
            for (int i = 0; i < iArray.Length; i++)
            {
                Console.WriteLine(iArray[i]);
            }
