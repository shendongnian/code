        public static void Main()
        {
            byte[] bArray = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            
            using (StreamWriter outfile =
            new StreamWriter(@"C:\\fileout.txt"))
            {
                foreach (var b in bArray)
                {
                    outfile.Write(b);
                }
            }
            Console.ReadLine();
        }
