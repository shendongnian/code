    using System;
    using System.Text;
    
    class Program
    {
    	static void Main(string[] args)
    	{
            string junk = "dÃ©jÃ\xa0";  // Bad Unicode string
            // Turn string back to bytes using the original, incorrect encoding.
            byte[] bytes = Encoding.GetEncoding(1252).GetBytes(junk);
            // Use the correct encoding this time to convert back to a string.
            string good = Encoding.UTF8.GetString(bytes);
            Console.WriteLine(good);
        }
    }
