    static void Main(string[] args)
            {
                int[] input = new[] { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
                int[] expectedOutput = new[] { 1, 3, 3, 4, 5 };
    
                int[] solution = TryGetSolution(input);
    
                Console.WriteLine("Input: " + FormatNumbers(input));
                Console.WriteLine("Expected Output: " + FormatNumbers(expectedOutput));
                Console.WriteLine("Output: " + FormatNumbers(solution));
                Console.ReadLine();
            }
    
            private static string FormatNumbers(int[] numbers)
            {
                return string.Join(", ", numbers);
            }
    
            private static int[] TryGetSolution(int[] input)
            {
                return TryWithoutAnyItem(input);
            }
    
            private static int[] TryWithoutAnyItem(int[] items)
            {
                return Enumerable.Range(0, items.Length)
                                 .Select(i => TryWithoutItem(items, i))
                                 .Where(solution => solution != null)
                                 .OrderByDescending(solution => solution.Length)
                                 .FirstOrDefault();
            }
    
            private static int[] TryWithoutItem(int[] items, int withoutIndex)
            {
                if (IsSorted(items)) return items;
                var removed = items.Take(withoutIndex).Concat(items.Skip(withoutIndex + 1));
                return TryWithoutAnyItem(removed.ToArray());
            }
    
            private static bool IsSorted(IEnumerable<int> items)
            {
                return items.Zip(items.Skip(1), (a, b) => a.CompareTo(b)).All(c => c <= 0);
            }
        }
