      public static string ToArabicNumber(this string inputString)
        {
            string[] arabicDigits = CultureInfo.GetCultureInfo("fa-IR").NumberFormat.NativeDigits;
            var arabicNumberBuilder = new StringBuilder();
            foreach (char c in inputString)
            {
                if (char.IsDigit(c))
                    arabicNumberBuilder.Append(arabicDigits[int.Parse(c.ToString())]);
                else
                    arabicNumberBuilder.Append(c);
            }
            return arabicNumberBuilder.ToString();
        }
