    using System;
    using System.Diagnostics;
    namespace Test
        {
        class Program
            {
            static void Main ( string[] args )
                {
                Debug.WriteLine( "blah".ToInt64() );
                Debug.WriteLine( "432123".ToInt64() );
                Debug.WriteLine( "123904810293841209384".ToInt64( -1 ) );
                Debug.WriteLine( "this is not a DateTime value".ToDateTime() );
                Debug.WriteLine( "this is not a DateTime value".ToDateTime( "jan 1, 1970 0:00:00".ToDateTime() ) );
                Debug.WriteLine( "2013/01/30 12:00:00".ToDateTime() );
                Debug.WriteLine( "this is not a decimal value".ToDecimal( -1 ) );
                Debug.WriteLine( "12342.3233443".ToDecimal() );
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
            static public DateTime ToDateTime ( this string value )
                {
                return value.ToDateTime( default( DateTime ) );
                }
            static public DateTime ToDateTime ( this string value, DateTime defaultValue )
                {
                DateTime result;
                if ( DateTime.TryParse( value, out result ) )
                    {
                    return result;
                    }
                return defaultValue;
                }
            static public decimal ToDecimal ( this string value )
                {
                return value.ToDecimal( default( decimal ) );
                }
            static public decimal ToDecimal ( this string value, decimal defaultValue )
                {
                decimal result;
                if ( decimal.TryParse( value, out result ) )
                    {
                    return result;
                    }
                return defaultValue;
                }
            }
        }
