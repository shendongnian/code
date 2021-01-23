    public class TransposeLetters
    {
        public Dictionary<char, char> Odd { get; private set; }
        public Dictionary<char, char> Even { get; private set; }
    
        public TransposeLetters()
        {
            Odd = new Dictionary<char, char>();
    
            // capital leters
            for( int i = 65; i <= 90; i += 2 )
            {
                Odd.Add( (char)i, (char)( i + 1 ) );
            }
    
            // small letters
            for( int i = 97; i <= 122; i += 2 )
            {
                Odd.Add( (char)i, (char)( i + 1 ) );
            }
    
            Even = Odd.ToDictionary( x => x.Value, x => x.Key );
        }
    
        public string Convert( string str )
        {
            // ensure only letters are passed into the method
            var cleansed = str.Where( char.IsLetter );
    
            var transposed = cleansed.Select( x => Odd.ContainsKey( x ) ? Odd[x] : Even[x] );
    
            var result = new string( transposed.ToArray() );
    
            return result;
        }
    }
