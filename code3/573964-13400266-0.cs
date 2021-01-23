    static void Main(string[] args)
        {
            Sumator s1 = new Sumator();
            double userDouble; //moved declaration out of while loop
            s1.ZmienStatus();
            // Sprawdzanie czy w stringu sa liczby
            bool userNum = true;
            while (userNum)
            {
                
                string userString = Console.ReadLine();
                // Jesli sa liczby to convertujemy
                if (userNum = double.TryParse(userString, out userDouble))
                {
                    userDouble = Convert.ToDouble(userString);
                    userNum = false;
                }
                else 
                {
                    Console.WriteLine("Nie podano liczby!");
                    userNum = true;
                }
            }
            s1.Kalk.PodajDzialanie(userDouble, 2, "*");
            s1.PokazWynikS();
            s1.Kalk.PokazWynik();
            s1.Kalk.PodajDzialanie(userDouble, 2, "+");
            s1.PokazWynikS();
            s1.Kalk.PokazWynik();
            Console.ReadKey();
        }
