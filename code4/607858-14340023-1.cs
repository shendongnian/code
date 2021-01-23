    public static class StringExtensions
    {
        public static string Reverse(this string s)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            bool wasFormD = false;
            if (s.IsNormalized(NormalizationForm.FormD))
            {
                wasFormD = true;
                // Normalize to form C so that composite chars are represented as a single char
                s = s.Normalize(NormalizationForm.FormC);
            }
            s = new String(((IEnumerable<char>)s).Reverse().ToArray());
            // Restore normalization form D
            if (wasFormD)
            {
                s = s.Normalize(NormalizationForm.FormD);
            }
            return s;
        }
    }
