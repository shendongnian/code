        static void Main(string[] args)
        {
            string[] strList1 = new string[] { "TDC1ABF", "TDC1ABI", "TDC1ABO" };
            string[] strList2 = new string[] { "TDC2ABF", "TDC2ABI", "TDC2ABO" };
            string[] strList3 = new string[] { "TDC3ABF", "TDC3ABO", "TDC3ABI" };
            arrange(strList1);
            arrange(strList2);
            arrange(strList3);
        }
        public static void arrange(string[] list)
        {
            Console.WriteLine("OUT OF ORDER");
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            for (int x = 0; x < list.Length - 1; x++)
            {
                char[] temp = list[x].ToCharArray();
                char[] temp1 = list[x + 1].ToCharArray();
                int sum = 0;
                foreach (char letter in temp)
                {
                    sum += (int)letter; //This adds the ASCII value of each char 
                }
                int sum2 = 0;
                foreach (char letter in temp1)
                {
                    sum2 += (int)letter; //This adds the ASCII value of each char 
                }
                if (sum > sum2)
                {
                    string swap1 = list[x];
                    list[x] = list[x + 1];
                    list[x + 1] = swap1;
                }
            }
            Console.WriteLine("IN ORDER");
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
