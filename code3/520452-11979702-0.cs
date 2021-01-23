    static void inputPartInformation(string[] pl)
        {
            int i = 0;
            do
            {
                Console.Write("Enter a Name: ");
                //for the player
                newStrInput = Console.ReadLine();
    
    if (newStrInput == "Q")
    break;//if they write Q for the player it will quit
    
    pl[i]=newStrInput;
    i++;
         }
            while (i>-1);//infinite loop        
    
        }
