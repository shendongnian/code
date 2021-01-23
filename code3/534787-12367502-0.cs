    public static class RandomStringService
    {
        //Generate new random every time used. Must sit outside of the function, as static, otherwise there would be no randomness.
        private static readonly Random Rand = new Random((int)DateTime.Now.Ticks);
        /// <summary>
        /// Create random unique string- checking against a table
        /// </summary>
        /// <returns>Random string of defined length</returns>
        public static String GenerateUniqueRandomString(int length)
        {
            //check if the string is unique in Barcode table.
            String newCode;
            do
            {
                newCode = GenerateRandomString(length);
             // and check if there is no duplicates, regenerate the code again.
            } while (_tableRepository.AllRecords.Any(l => l.UniqueString == newCode));
    //In my case _tableRepository is injected via DI container and represents a proxy for 
    //EntityFramework context. This step is not really necessary, most of the times you can use 
    //method below: GenerateRandomString
            return newCode;
        }
        /// <summary>
        /// Generates the random string of given length.
        /// String consists of uppercase letters only.
        /// </summary>
        /// <param name="size">The required length of the string.</param>
        /// <returns>String</returns>
        private static string GenerateRandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(CreateRandomIntForString());
                builder.Append(ch);
            }
            return builder.ToString();
        }
        /// <summary>
        /// Create a random number corresponding to ASCII uppercase or a digit
        /// </summary>
        /// <returns>Integer between 48-57 or between 65-90</returns>
        private static int CreateRandomIntForString()
        {
            //ASCII codes
            //48-57 = digits
            //65-90 = Uppercase letters
            //97-122 = lowercase letters
            int i;
            do
            {
                i = Convert.ToInt32(Rand.Next(48, 90));
            } while (i > 57 && i < 65);
            return i;
        }
