    public void CheckWinner(Buttons[] buttonArray)
    {
        int arrLength = buttonArray.Length; 
        int foundCount = 0;
    
        for (int i = 0; i < arrLength ; i++)
        { 
            string buttonText = buttonArray[i].Text;
            if(buttonText == "X" && (i+1) % 5 == 0) foundCount++;
        }
    
        if(foundCount == 5 )
            Console.WriteLine("Found it !");
    }
