            public string InsertSpaceBetweenLetters(string S, int spaceWidth) {
            Contract.Requires(spaceWidth > 0);
            Contract.Requires(S != null);
            Contract.Requires(S.Length > 0);
            Contract.Ensures(Contract.Result<string>() != null);
            Contract.Ensures(Contract.Result<string>().Length == S.Length + (S.Length - 1) * spaceWidth);
            StringBuilder result = new StringBuilder(String.Empty);
            int count = 0;
            int final = S.Length - 1;
            foreach ( char c in S )
            {
                result.Append(c, 1);
                if ( count < final )
                {
                    result.Append(' ', spaceWidth);
                }
                ++count;
            }
            return result.ToString();
        }
