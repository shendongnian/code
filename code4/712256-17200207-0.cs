    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace TestRegex
    {
        class Program
        {
            static void Main( string[] args )
            {
                var path = @"settings.txt";
                var pattern = @"(^\s*books_book\d+\s*=\s*)(\d+)(\s*)$";
                var options = RegexOptions.IgnoreCase | RegexOptions.Multiline;
                var contents = Regex.Replace( File.ReadAllText( path ), pattern, MyMatchEvaluator, options );
                File.WriteAllText( path, contents );
            }
    
            static int x = char.ConvertToUtf32( "a", 0 );
    
            static string MyMatchEvaluator( Match m )
            {
                var x1 = m.Groups[ 1 ].Value;
                var x2 = char.ConvertFromUtf32( x++ );
                var x3 = m.Groups[ 3 ].Value;
                var result = x1 + x2 + x3;
                return result;
            }
        }
    }
