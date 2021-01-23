    public class Permutations
    {
        public static string[][] GenerateAllPermutations(string[] tokens, int depth)
        {
            string[][] permutations = new string[depth][];
            permutations[0] = tokens;
            for (int i = 1; i < depth; i++)
            {
                string[] parent = permutations[i - 1];
                string[] current = new string[parent.Length * tokens.Length];
                for (int parentNdx = 0; parentNdx < parent.Length; parentNdx++)
                    for (int tokenNdx = 0; tokenNdx < tokens.Length; tokenNdx++)
                        current[parentNdx * tokens.Length + tokenNdx] = parent[parentNdx] + tokens[tokenNdx];
                permutations[i] = current;
            }
            return permutations;
        }
        public static void Test()
        {
            string[] tokens = new string[] { "x", "y", "z" };
            int depth = 4;
            string[][] permutations = GenerateAllPermutations(tokens, depth);
            for (int i = 0; i < depth; i++)
            {
                foreach (string s in permutations[i])
                    Console.WriteLine(s);
                Console.WriteLine(string.Format("Total permutations:  {0}", permutations[i].Length));
                Console.ReadKey();
            }
        }
    }
