    using System;
    using System.IO;
    using Microsoft.VisualBasic.FileIO;
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.OpenRead("input.txt");
            using(var tfp = new TextFieldParser(input))
            {
                tfp.SetDelimiters(new string[] { ";" });
                tfp.HasFieldsEnclosedInQuotes = true;
                var fields = tfp.ReadFields();
                foreach (var field in fields)
                {
                    Console.WriteLine(field);
                }
            }
        }
    }
