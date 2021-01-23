    /// <summary>
        /// this extension gets the next hunfìdred for any number you whant
        /// </summary>
        /// <param name="i">numeber to rounded</param>
        /// <returns>the next hundred number</returns>
        /// <remarks>
        /// eg.:
        /// i =   21 gets 100
        /// i =  121 gets 200
        /// i = 1211 gets 1300
        /// </remarks>
        public static int RoundToNextHundred(this int i)
        {
            return i += (100 - i % 100);
        }
