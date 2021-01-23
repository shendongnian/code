        public static List<int> DecomposeInPowerOf10(int number)
        {
            if (number < 0) return null;
            if (number < 10) return new List<int> {number};
            List<int> result = new List<int>();
            char[] digits = number.ToString(CultureInfo.InvariantCulture).ToArray();
            for (int i = 0; i < digits.Length; i++)
            {
                int digit = digits[i] - '0';
                int value = digit * (int)(Math.Pow(10, (digits.Length - i - 1)));
                result.Add(value);
            }
            return result;
        }
