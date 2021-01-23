        static void Main(string[] args)
        {
            GetCombination(new List<char> { 'A','B','C' });
            Console.ReadKey();
        }
        static void GetCombination(List<char> list)
        {
            for (int i = 1; i < Convert.ToInt32(Math.Pow(2, list.Count)); i++)
            {
                int temp = i;
                string str = "";
                int j = Convert.ToInt32( Math.Pow(2, list.Count - 1));
                int index = 0;
                while (j > 0)
                {
                    if (temp - j >= 0)
                    {
                        str += list[index];
                        temp -= j;
                    }
                    j /= 2;
                    index++;
                }
                Console.WriteLine(str);
            }
        }
