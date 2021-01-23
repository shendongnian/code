    float Dollaro = 1.32f, Euro;
    float Cambio;
    string EuroStr;
            
         do
         {
            Console.Write("Euro: ");
            EuroStr = Console.ReadLine();
            Euro = float.Parse(EuroStr);
            Cambio = Dollaro * Euro;
            
            Console.WriteLine("Dollaro: " + Cambio);
            Console.WriteLine("Vuoi continuare? (yes/no)");
            Console.ReadLine();
            string risposta = Console.ReadLine();
            
                if (risposta.Equals("Y"))
                {
                    Console.WriteLine("Yes");
                    break;
                }
                else if (risposta.Equals("N"))
                {
                    Console.WriteLine("No");
                    break;
                }
          } while (risposta == "N");
