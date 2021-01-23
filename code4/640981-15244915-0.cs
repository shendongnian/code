            Console.BufferHeight = Int16.MaxValue - 1;
            Console.WindowHeight = 40;
            Console.WindowWidth = 120;
            Console.WriteLine("Enter your caracters for the anagram: ");
            //var d = Read();
            string line;
            //string DictionaryInput = System.IO.File.ReadAllText("Dictionary.txt");
            while ((line = Console.ReadLine()) != null)
            {
                Console.WriteLine("Your results are: ");
                char[] charArray = line.ToArray();
                //Show(d, line);                    //Using this to check that words found are the correct words in the dictionary.
                setper(charArray);
                Console.WriteLine("-----------------------------------------DONE-----------------------------------------");
                Console.WriteLine("Enter your caracters for the anagram: ");
                File.Delete("Permutations.txt");
            }
        }
     
        static void swap(ref char a, ref char b)
        {
            if (a == b) return;
            a ^= b;
            b ^= a;
            a ^= b;
        }
        static void setper(char[] list)
        {
            int x = list.Length - 1;
            permuteWords(list, 0, x);
        }
        static void permuteWords(char[] list1, int k, int m)
        {
            if (k == m)
            {
                StreamWriter sw = new StreamWriter("Permutations.txt", true);
                sw.WriteLine(list1);
                sw.Close();
                Regex permutationPattern = new Regex(new string(list1));
                string[] permutations = File.ReadAllLines("Permutations.txt");
                Regex pattern = new Regex(new string(list1));
                string[] lines = File.ReadAllLines("Dictionary.txt");
                foreach (string line in lines)
                {
                    var matches = pattern.Matches(line);
                    if (pattern.ToString() == line)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                for (int i = k; i <= m; i++)
                {
                    swap(ref list1[k], ref list1[i]);
                    permuteWords(list1, k + 1, m);
                    swap(ref list1[k], ref list1[i]);
                }
            }
        }
