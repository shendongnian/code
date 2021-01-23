        public static string[] ExtractNumbers(string[] originalCodeLines)
        {
            List<string> extractedNumbers = new List<string>();
            string[] codeLineElements = originalCodeLines[0].Split('"');
            foreach (string element in codeLineElements)
            {
                int result = 0;
                if (int.TryParse(element, out result))
                {
                    extractedNumbers.Add(element);
                }
            }
            return extractedNumbers.ToArray();
        }
