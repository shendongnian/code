        static void Main(string[] args)
        {
            byte [] bArray = new byte[] {11, 67, 67, 67, 33, 34, 67, 67, 11, 33, 67, 67, 67, 67};
            byte[] result = Replace(bArray, new byte[] {67, 67, 67}, new byte[] {90});
            foreach (byte b in result)
            {
                Console.WriteLine(b);
            }
        }
        private static byte [] Replace(byte[] input, byte[] pattern, byte[] replacement)
        {
            if (pattern.Length == 0)
            {
                return input;
            }
            List<byte> result = new List<byte>();
            int i;
            for (i = 0; i <= input.Length - pattern.Length; i++)
            {
                bool foundMatch = true;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (input[i + j] != pattern[j])
                    {
                        foundMatch = false;
                        break;
                    }
                }
                if (foundMatch)
                {
                    result.AddRange(replacement);
                    i += pattern.Length - 1;
                }
                else
                {
                    result.Add(input[i]);
                }
            }
            for (; i < input.Length; i++ )
            {
                result.Add(input[i]);
            }
            return result.ToArray();
        }
