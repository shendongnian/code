    static void Main(string[] args)
        {
            string Text = "ABCDEFGHIJKLMNOPQ";
          
           
            int chunk = new Random().Next(1,Text.Length/2);
          
            var result= Split(Text,chunk);
            Console.WriteLine("Splited:");
           
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
            string toOld = "";
            Console.WriteLine("Returned:");
            toOld = result.Aggregate((i, j) => i + j);
            Console.WriteLine(toOld);
            Console.ReadLine();
            
        }
        static List<string> Split(string str, int chunkSize)
        {
            var re = Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize)).ToList() ;
            var temp = re.Aggregate((i, j) => i + j);
            if (temp.Length < str.Length)
            {
                var last = re.Last();
                last += str.Substring(temp.Length, str.Length - temp.Length);
                re[re.Count-1] = last;
            }
            return re;
        }
