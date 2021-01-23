        public static string Truncate(this string pThis, int pLength)
        {
            if (string.IsNullOrEmpty(pThis))
                return pThis;
            if (0 >= pLength)
                return string.Empty;
            var lTruncatedString = pThis;
            const string lEllipses = @"…";
            if (pThis.Length > pLength)
            {
                var lSubstringLength = Math.Max(pLength - lEllipses.Length, 0);
                lTruncatedString = pThis.Substring(0, lSubstringLength) + lEllipses;
                if (lTruncatedString.Length > pLength)
                    lTruncatedString = lTruncatedString.Substring(0, pLength);
            }
            return lTruncatedString;
