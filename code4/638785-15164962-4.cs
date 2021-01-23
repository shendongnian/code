    public void CheckWinner(Buttons[] buttonArray)
    {
        int arrLength = buttonArray.Length; 
        int hCount = 0;
        //int vCount = 0;
        double root = Math.Sqrt(Convert.ToDouble(arrLength));  
        for (int i = 0; i < arrLength ; i++)
        { 
            string bText = buttonArray[i].Text;
            hCount = i % 5 == 0? 0 : hCount;
            
            if(bText == "X") 
                hCount++;
            if(hCount == Convert.ToInt32(root)) 
            {
                Console.WriteLine("Horizontal row winner found !");
                break;
            }
        }
    
    }
