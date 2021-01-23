    /// <summary>
        /// this extension gets the next hunfìdred for any number you whant
        /// </summary>
        /// <param name="i">numeber to rounded</param>
        /// <returns>the next hundred number</returns>
        /// <remarks>
        /// eg.:
        /// i =   21 gets 100
        /// i =  121 gets 200
        /// i =  200 gets 300
        /// i = 1211 gets 1300
        /// i = -108 gets -200
        /// </remarks>
        public static int RoundToNextHundred(this int i)
        {
            return i += (100 * Math.Sign(i) - i % 100);
            //use this line below if you want RoundHundred not NEXT
            //return i % 100 == byte.MinValue? i : i += (100 * Math.Sign(i) - i % 100);
        }
