    static int inputPartInformation(string[] pl)
        {
            int i = 0;
            String temp;
            while (true)
            {
                Console.Write("Enter a Name: ");
                temp=Console.ReadLine();
                if (temp=="Q")
                    break;
                else pl[i++] = temp;
            }
            return i;
        }
        static void Main(string[] args)
        {
            String[] players = new String[100];
    
            int size=inputPartInformation(players);
            for (int i = 0; i <= size; i++)
                Console.WriteLine(players[i]);
            
        }
    }
