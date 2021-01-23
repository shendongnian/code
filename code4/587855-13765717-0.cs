        /// <summary>
        /// Determines if a <code>DateTime</code> falls before another <code>DateTime</code> (inclusive)
        /// </summary>
        /// <param name="dt">The <code>DateTime</code> being tested</param>
        /// <param name="compare">The <code>DateTime</code> used for the comparison</param>
        /// <returns><code>bool</code></returns>
        public static bool isBefore(this DateTime dt, DateTime compare)
        {
            return dt.Ticks <= compare.Ticks;
        }
        /// <summary>
        /// Determines if a <code>DateTime</code> falls after another <code>DateTime</code> (inclusive)
        /// </summary>
        /// <param name="dt">The <code>DateTime</code> being tested</param>
        /// <param name="compare">The <code>DateTime</code> used for the comparison</param>
        /// <returns><code>bool</code></returns>
        public static bool isAfter(this DateTime dt, DateTime compare)
        {
            return dt.Ticks >= compare.Ticks;
        }
