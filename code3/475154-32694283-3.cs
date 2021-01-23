    using System;
    using ....;
    using QUT.Gppg;
    using Scanner;
    using Parser;
    
    namespace NCParser
    {
    class Program
    {
        static void Main(string[] args)
        {
            string pathTXT = @"C:\temp\testFile.txt";
            FileStream file = new FileStream(pathTXT, FileMode.Open);
            Scanner scanner = new Scanner();
            scanner.SetSource(file, 0);
            Parser parser = new Parser(scanner);            
        }
    }
    }    
