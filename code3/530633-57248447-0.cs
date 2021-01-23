    class Program
    {
        static List<string> textArr = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static void Main(string[] args)
        {
            getCombination();
        }
       static void getCombination() {
            var maxCombination = 1;
            List<string> Combinations = new List<string>();
            for (var i = 1; i < textArr.Count(); i++)
            {
                maxCombination = maxCombination * i;
            }
            while (Combinations.Count<maxCombination)
            {
                var temp = string.Join(" ", textArr.OrderBy(x => Guid.NewGuid()).ToList());
                if (Combinations.Contains(temp))
                {
                    continue;
                }
                else {
                    Combinations.Add(temp);
                }
            }
        }
    }
