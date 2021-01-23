        public int[] ExtractNumbers(string numbers)
        {
            return numbers
                .ToCharArray()
                .Select(x => Int32.Parse(x.ToString(CultureInfo.CurrentCulture)))
                .ToArray();
        }
