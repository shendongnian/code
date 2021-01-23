    static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"C:\Users\achikhale\Desktop\file.txt");
            string[] array1File = File.ReadAllLines(@"C:\Users\achikhale\Desktop\array1.txt");
            string[] array2File = File.ReadAllLines(@"C:\Users\achikhale\Desktop\array2.txt");
            List<string> finalResultarray1File = new List<string>();
            List<string> finalResultarray2File = new List<string>();
            foreach (string inputstring in input)
            {
                string[] wordTemps = inputstring.Split(' ');//  .Split(' ');
                foreach (string array1Filestring in array1File)
                {
                    string[] word1Temps = array1Filestring.Split(' ');
                    var result = word1Temps.Where(y => !string.IsNullOrEmpty(y) && wordTemps.Contains(y)).ToList();
                    if (result.Count > 0)
                    {
                        finalResultarray1File.AddRange(result);
                    }
                }
            }
            foreach (string inputstring in input)
            {
                string[] wordTemps = inputstring.Split(' ');//  .Split(' ');
                foreach (string array2Filestring in array2File)
                {
                    string[] word1Temps = array2Filestring.Split(' ');
                    var result = word1Temps.Where(y => !string.IsNullOrEmpty(y) && wordTemps.Contains(y)).ToList();
                    if (result.Count > 0)
                    {
                        finalResultarray2File.AddRange(result);
                    }
                }
            }
            if (finalResultarray1File.Count > 0)
            {
                Console.WriteLine("file array1.txt contians words: {0}", string.Join(";", finalResultarray1File));
            }
            if (finalResultarray2File.Count > 0)
            {
                Console.WriteLine("file array2.txt contians words: {0}", string.Join(";", finalResultarray2File));
            }
            Console.ReadLine();
        }
    }
