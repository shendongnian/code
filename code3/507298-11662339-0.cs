    class Program
    {
        static void Main(string[] args)
        {
            // List of strings that you may consider it from your 
            /// database which is String1
            List<string> lstStrings = new List<string>();
            lstStrings.Add("twenty one");
            lstStrings.Add("twenty two");
            lstStrings.Add("twenty three");
            lstStrings.Add("twenty four");
            
            // The string to compare to which is your String2
            string strString = "one two four";
            // Splitting the strings to be compared
            string[] strArray = strString.Split(' '); 
            // The linq that helps you query the data exactly as what you wanted
            var result = (from string A in lstStrings
                                   from string B in strArray
                                   where A.Contains(B)
                                   select A).Distinct();
            
            // Count result
            Console.WriteLine(result.Count());
            // Individual values
            foreach (string str in result)
            {
                Console.WriteLine(str);
            }
            
            Console.ReadLine();
        } 
    }
