    class Program
    {
        static void Main(string[] args)
        {
            var allProfessionals =
                new Collection<Professional>
                    {
                        new Professional {Name = "Bruno Paulovich Silva"},
                        new Professional {Name = "Ivan Silva Paulovich Bruno"},
                        new Professional {Name = "Camila Campos"}
                    };
            var namesSearch = new[] {"bruno", "silva"};
            var items = allProfessionals
                .Select(x => x.Name)
                .ContainsAll(namesSearch);
            foreach (var res in items)
            {
                Console.WriteLine(res);
            }
        }
    }
    static class Extensions
    {
        public static IEnumerable<string> ContainsAll(this IEnumerable<string> haystacks, IEnumerable<string> needles)
        {
            var lowerNeedles = needles.Select(x => x.ToLower()).ToList();
            var lowerHay = haystacks.Select(x => x.ToLower()).ToList();
            // note that Regex may be faster than .Contains with larger haystacks
            return lowerNeedles
                .Where(hay => lowerHay.All(hay.Contains));
        }
    }
