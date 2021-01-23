    using System.Diagnostics;
    namespace Test
        {
        class Program
            {
            static void Main ( string[] args )
                {
                Debug.WriteLine( "blah".ToInt64() );
                Debug.WriteLine( "432123".ToInt64() );
                Debug.WriteLine( "123904810293841209384".ToInt64() );
                Debug.WriteLine( "123904810293841209384".ToInt64( -1 ) );
                }
            }
        static public class Extensions
            {
            static public long ToInt64 ( this string value )
                {
                return value.ToInt64( default( long ) );
                }
            static public long ToInt64 ( this string value, long defaultValue )
                {
                long result;
                if ( long.TryParse( value, out result ) )
                    {
                    return result;
                    }
                return defaultValue;
                }
            }
        }
