    public static void ArrayNumbersCount()
        {
            int number=0;
            int count=1;
            Dictionary<int, int> collection = new Dictionary<int, int>();
            int[] intergernumberArrays = { 1, 2, 3, 4, 1, 2, 4, 1, 2, 3, 5, 6, 1, 2, 1, 1, 2 };
            for (int i = 0; i < intergernumberArrays.Length; i++)
            {
                number = int.Parse(intergernumberArrays[i].ToString());
                if (!collection.ContainsKey(number))
                {
                    for (int j = i + 1; j < intergernumberArrays.Length; j++)
                    {
                        if (int.Parse(intergernumberArrays[i].ToString()) == int.Parse(intergernumberArrays[j].ToString()))
                        {
                            count++;
                        }
                    }
                    collection.Add(number, count);
                }
                count = 1;
                number = 0;
            }
            foreach (var kvp in collection.ToList())
            {
                Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);                
            }            
        }
