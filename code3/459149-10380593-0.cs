    using System;
    public class Test
    {
    	public static void Main()
    	{		
    			TestPal( "Michael", 3 );                
    			TestPal( "racecar", 3 );
    			TestPal( "katutak", 3 );
    			TestPal( "able was i ere i saw elba", 7 );
    			TestPal( "radar", 2 );
    			TestPal( "radars", 2 );
                        // This is false, space is considered ;-)
    			TestPal( "a man a plan a canal panama", 9 );
    	}
    
        static void TestPal(string s, int count) {
            Console.WriteLine( "{0} : {1}", s, IsBothEndsPalindrome(s, count) );
        }
    
        static bool IsBothEndsPalindrome(string s, int count) {           
            while(--count > 0 && s[count] == s[s.Length - count - 1]);
            return count == 0;
        }
    }
