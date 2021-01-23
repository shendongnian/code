    using System;
    using System.Linq;
    
    class OneLiner
    {
        static void Main()
        {
        string s = "TextHereTisImortant973End"; //Between "eT" and "97"
        Console.WriteLine(s.Substring(s.IndexOf("eT") + "eT".Length)
                           .Split("97".ToCharArray()).First());
        }
    }
