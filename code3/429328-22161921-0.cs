    public static class IntegerExtensions
    {
        /// <summary>
        /// converts an integer to its ordinal representation
        /// </summary>
        public static String AsOrdinal(this Int32 number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException("number");
            var work = number.ToString("n0");
            var modOf100 = number % 100;
            if (modOf100 == 11 || modOf100 == 12 || modOf100 == 13)
                return work + "th";
            switch (number % 10)
            {
                case 1:
                    work += "st"; break;
                case 2:
                    work += "nd"; break;
                case 3:
                    work += "rd"; break;
               default:
                    work += "th"; break;
            }
            return work;
        }
    }
