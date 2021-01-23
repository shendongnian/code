    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main()
        {
            // You can create the regex once and reuse it, of course. Adjust
            // as necessary if the name isn't always "xyz" for example.
            Regex regex = new Regex(@"^#def xyz\[timer=(\d+), fill=(\d+)\]$");
            string input = "#def xyz[timer=50, fill=10]";
            Match match = regex.Match(input);
            if (match.Success)
            {
                int fill = int.Parse(match.Groups[1].Value);
                int timer = int.Parse(match.Groups[2].Value);
                Console.WriteLine("Fill={0}, timer={1}", fill, timer);
            }
        }
    }
