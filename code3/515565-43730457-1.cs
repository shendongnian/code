            int[] intergernumberArrays = { 1, 2, 3, 4, 1, 2, 4, 1, 2, 3, 5, 6, 1, 2, 1, 1, 2 };
            Dictionary<int, int> NumberOccurence = new Dictionary<int, int>();
            for (int i = 0; i < intergernumberArrays.Length; i++)
            {
                if (NumberOccurence.ContainsKey(intergernumberArrays[i]))
                {
                    var KeyValue = NumberOccurence.Where(j => j.Key == intergernumberArrays[i]).FirstOrDefault().Value;
                    NumberOccurence[intergernumberArrays[i]] = KeyValue + 1;
                }
                else
                {
                    NumberOccurence.Add(intergernumberArrays[i], 1);
                }
            }
            foreach (KeyValuePair<int, int> item in NumberOccurence)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            Console.ReadLine();
        }
