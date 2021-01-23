     private static readonly string[] pn = { "ی", "ک" };
        private static readonly string[] ar = { "ي", "ك" };
        public static string ToFaText(this string strTxt)
        {
            string chash = strTxt;
            for (int i = 0; i < 2; i++)
                chash = chash.Replace(ar[i],pn[i]);
            return chash;
        }
