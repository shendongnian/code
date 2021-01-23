        static void Main(string[] args)
        {
        	float Dollaro = 1.32f, Euro;
        	float Cambio;
        	string EuroStr;
        
        	string risposta = "Y";
        
        	do
        	{
        		Console.Write("Euro: ");
        		EuroStr = Console.ReadLine();
        		Euro = float.Parse(EuroStr);
        
        		Cambio = Dollaro * Euro;
        
        		Console.WriteLine("Dollaro: " + Cambio);
        		Console.WriteLine("Vuoi continuare? (yes/no)");               
        		risposta = Console.ReadLine();
        
        		if (risposta.Equals("Y"))
        		{
        			Console.WriteLine("Yes");                    
        		}
        		else if (risposta.Equals("N"))
        		{
        			Console.WriteLine("No");                    
        		}
        
        	} while (risposta == "Y");
        }
       
