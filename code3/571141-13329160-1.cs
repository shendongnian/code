    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace GameEdition3
    {
    class Program
    {
        static void Main(string[] args)
        {
    
            Data classData = new Data();
    
            Console.WriteLine("{0}", classData.TitleMenu());
    
            while (true) 
            {
                ConsoleKeyInfo PressKey;
                PressKey = Console.ReadKey();
    
                if (PressKey.Key == ConsoleKey.Backspace)
                {
                    Console.Clear();
                    Console.WriteLine("{0}", classData.TitleMenu());
                }
                else if (PressKey.Key == ConsoleKey.I)
                {
                    Console.Clear();
                    Console.WriteLine("{0}", classData.Information());
                }
                else if (PressKey.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.Write("Please type in the Item you want. Warhammer, Heavy Armor, Boots, or Sword: ");
                    Console.WriteLine("{0}", classData.myFunction());
                    Console.WriteLine("\nPress Backspace to go back to the menu and you can view your item in the Display all Items tab");
                }
                else if (PressKey.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("{0}", classData.result);
                }
                else if (PressKey.Key == ConsoleKey.D3)
                {
                    Console.Clear();
                }
                else if (PressKey.Key == ConsoleKey.D4)
                {
                    return;
                }
            }
        }
    
    
    }
    }
