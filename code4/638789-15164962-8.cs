    public void CheckWinner(Buttons[] buttonArray)
    {
        int arrLength = buttonArray.Length; 
        int hCount = 0;
        //int vCount = 0;
        int root = (int)Math.Sqrt(Convert.ToDouble(arrLength));  
        for (int i = 0; i < arrLength ; i++)
        { 
            string bText = buttonArray[i].Text;
            hCount = i % root == 0? 0 : hCount;
            
            if(bText == "X") 
                hCount++;
            if(hCount == root) 
            {
                Console.WriteLine("Horizontal row winner found !");
                break;
            }
        }
    
    }
