        public Dictionary<string,int> removeDupUsingDictionary(int[] n)
        {
            Dictionary<string,int> numbers = new Dictionary<string,int>();
            for( int i = 0 ; i< n.Length; i ++)
            {
                try
                {
                    numbers.Add("value" + n[i], n[i]);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Already the value" + n[i] + "present in the dictionary");
                }
            }
            return numbers;
        }
        static void Main(string[] args)
        {
            Program num = new Program();
            int[] n = { 6,5,1, 2, 3, 4, 5, 5, 6,6,6,6,6,6 };
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            int size = n.Length;
            
            ArrayList actual = num.removeDup(n);
            num.removeDupUsingDictionary(n);
        }
