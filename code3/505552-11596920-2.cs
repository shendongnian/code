        static void Main(string[] args)
        {
            var haystacks = new[] {
                "Lorem ipsum dolor sit amet, justo",
                "notgin like good cold beer"
            };
            var needles = new[] {"justo", "beer", "lorem"};
            foreach (var haystack in haystacks) {
                Console.Write(haystack + "  contains --> ");
                var matches = MatchingStrings(haystack, needles);
                Console.WriteLine(String.Join(",", matches));
            }
            Console.ReadLine();
        }
