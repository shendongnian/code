        private static readonly SortedSet<char> setOfVowels = new SortedSet<char>( "aeiouAEIOU" ) ;
        private static string ExtractVowels_3( string s )
        {
            if ( s == null ) throw new ArgumentNullException("s");
            string vowels = new string( s.Where( c => setOfVowels.Contains(c) ).ToArray() ) ;
            return vowels ;
        }
