    class Program
    {
        static void Main(string[] args)
        {
            string aKnight = "Romulus";
            string bKnight = "Remus";
            string Weapon;
            Console.WriteLine($"{aKnight} implies {bKnight} is unorthodox.");
            /*Console.ReadLine();*/
            Console.WriteLine($"{bKnight} deicdes to hit {aKnight}. What should he use? Club, Bow, or Tactical Nuke?");
            /*Console.ReadLine();*/
            
            do
            {
                Weapon = Console.ReadLine();
                switch (Weapon)
                {
                    case "Club":
                        Console.WriteLine("Works for me.");
                        Console.WriteLine($"{bKnight} knocks {aKnight} out with the club.");
                        Console.ReadLine();
                        break;
                    case "Bow":
                        Console.WriteLine("Eh, creative yet acceptable.");
                        Console.WriteLine($"{bKnight} hits {aKnight} over the head with the bow. It just hurt a little.");
                        Console.ReadLine();
                        break;
                    case "Tactical Nuke":
                        Console.WriteLine("Are.. Are you serious? For the love of... JUST WHY?!");
                        Console.WriteLine("TACTICAL NUKE INBOUND!!!... It lagged...");
                        Console.ReadLine();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please make a choice.");
                        //Console.ReadLine();
                        break;
                }
            } while (Weapon != default && Weapon != "Club" && Weapon != "Bow" && Weapon != "Tactical Nuke");
                Console.WriteLine("What will happen next ?");
                Console.ReadLine();
        }
    }
    }
