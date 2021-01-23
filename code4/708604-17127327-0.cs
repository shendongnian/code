    class Program
    {
        static void Main(string[] args)
        {
            foreach (var comment in File.ReadAllLines(@"..\..\comments.txt"))
                Console.WriteLine(GetRating(comment));
            Console.ReadLine();
        }
        static double GetRating(string comment)
        {
            double rating = double.NaN;
            var wordsLines = from line in File.ReadAllLines(@"..\..\words.txt")
                             where !String.IsNullOrEmpty(line)
                             select Regex.Replace(line, @"\s+", " ");
            var wordRatings = from wLine in wordsLines
                              select new { Word = wLine.Split()[0],  Rating = Double.Parse(wLine.Split()[1]) };
            foreach (var wr in wordRatings)
            {
                if (comment.ToLower().Split(new Char[] {' ', ',', '.', ':', ';'}).Contains(wr.Word))
                    rating = wr.Rating;
            }
            return rating;
        }
    }
