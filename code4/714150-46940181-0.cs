       static void Main(string[] args)
        {
            String text = "One=1,Two=2,ThreeFour=34";
    
            Console.WriteLine(betweenStrings(text, "One=", ",")); // 1
            Console.WriteLine(betweenStrings(text, "Two=", ",")); // 2
            Console.WriteLine(betweenStrings(text, "ThreeFour=", "")); // 34
    
            Console.ReadKey();
    
        }
    
        public static String betweenStrings(String text, String start, String end)
        {
            int p1 = text.IndexOf(start) + start.Length;
            int p2 = text.IndexOf(end, p1);
    
            if (end == "") return (text.Substring(p1));
            else return text.Substring(p1, p2 - p1);                      
        }
