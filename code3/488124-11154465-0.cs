        static void Main(string[] args)
        {
            string str = "COMMSTR1-NAC-NAM-P-C FCPANAM1-NAC-NAM-P-C CHAZEL1-NAT-CBM-P-C";
            string[] flag = str.Split(' ');
            List<string> words = new List<string>();
            foreach (string f in flag)
            {
                words.Add(f.Split('-')[0]);
                words.Add(f.Remove(0, f.IndexOf('-') + 1));
            }
            foreach (string word in words)
            {
                Console.WriteLine("{0}", word);
            }
            Console.ReadLine(); 
        }
