     static void Main(string[] args)
        {
            isUniqueChart("text");
            Console.ReadKey();
        }
        static Boolean isUniqueChart(string text)
        {
            if (text.Length == 0 || text.Length > 256)
            {
                Console.WriteLine(" The text is empty or too larg");
                return false;
            }
            Boolean[] char_set = new Boolean[256];
            for (int i = 0; i < text.Length; i++)
            {
                int val = text[i];//already found this char in the string
                if (char_set[val])
                {
                    Console.WriteLine(" The text is not unique");
                    return false;
                }
                char_set[val] = true;
            }
            Console.WriteLine(" The text is unique");
            return true;
        }
