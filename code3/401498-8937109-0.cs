    /**
     * A program which is intended to "slowly" print text in green. 
     * A String read by the Console is converted to a char array and printed to the screen.
     * 
     * Information derived from Microsoft
    * -----------------------------------
     * Thread.Sleep is used in two ways: through a Timespan variable and through a direct call to the function.
     * Thread.Sleep(int) blocks the thread in milliseconds.
     * Thread.Sleep(Timespan) blocks the thread for a period of time measured in (int days, int hours, int minutes, int seconds).
     * Thread.Sleep is overloaded.
     * -----------------------------------
     * End Information
     * Source 1: http://msdn.microsoft.com/en-us/library/d00bd51t.aspx [Thread.Sleep(int)]
     * Source 2: http://msdn.microsoft.com/en-us/library/274eh01d.aspx [Thread.Sleep(Timespan)]
     * 
     **/
    using System;
    using System.Threading;
    namespace PlacidText
    {
    class Program
    {
        static TimeSpan interval1 = new TimeSpan(0, 0, 0, 1);
        static TimeSpan interval2 = new TimeSpan(0, 0, 0, 2);
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Placid Text, home of slow-typing.");
            while (true)			//loop
            {
                Console.WriteLine("Initializing Menu");
                Thread.Sleep(interval1);
                Console.WriteLine("Please select from the following options");
                Console.WriteLine("\'t\' to select slow-type,");
                Console.WriteLine("Input \'q\' to quit:");
                String screenselect = Console.ReadLine();
                if (string.Compare(screenselect, "t") == 0)
                {
                    Console.WriteLine("Slow-Type");
                    Slowtype slowtype = new Slowtype();		//new instance of Slow-Type
                    slowtype.PrintZeString();
                }
                else if (string.Compare(screenselect, "q") == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Bad input");
                }
            }
            Console.WriteLine("Ending Session");
            Thread.Sleep(interval2);
            Environment.Exit(1);
        }
        public class Slowtype
        {		//This class is used for Slowtype
            private string printy;
            public Slowtype()		//default constructor
            {
                printy = null;
            }
            public Slowtype(string printy)         //constructor
            {
                this.printy = printy;
            }
            public void PrintZeString()
            {
                Console.WriteLine("Please enter a string");
                printy = Console.ReadLine();
                Console.WriteLine("");
                char[] array = printy.ToCharArray();
                for (int i = 0; i < array.Length; i++)
                {
                    char letter = array[i];
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(letter);
                    Console.ResetColor();
                    Thread.Sleep(100);
                }
                Console.WriteLine("");
                return;
            }
        }
    }
