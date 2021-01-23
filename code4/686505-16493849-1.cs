        public static IEnumerable<int> ToCodepoints(this String s)
        {
            var codeunits = s.ToCharArray();
            var i = 0;
            while (i < codeunits.Length)
            {
                int codepoint;
                if (Char.IsSurrogate(codeunits[i]))
                {
                    codepoint = Char.ConvertToUtf32(codeunits[i], codeunits[i + 1]);
                    i += 2;
                }
                else
                {
                    codepoint = codeunits[i];
                    i += 1;
                }
                yield return codepoint;
            }
        }
