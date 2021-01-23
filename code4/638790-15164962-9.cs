    public void CheckWinner(Buttons[] buttonArray)
    {
        int arrLength = buttonArray.Length; 
        int hCount = 0;
        Int vCount = 0;
        int root = (int)Math.Sqrt(Convert.ToDouble(arrLength));  
        for (int i = 0;  i < root;  i++)
        {
            hCount = 0;
            vCount = 0;
            for(int j = 0;  j < root; j++)
            {
               if(buttonArray[ (i * root) + j ].Text == "X")
                  hCount++;
               if(buttonArray[ i + (root * j) ].Text == "X")
                  vCount++;
            }
            if( hCount + vCount == 2 * root)
            {
               Console.WriteLine("Horizontal and Virtical winner found !");
               break;
            } 
            else if ( hCount == root )
            { 
               Console.WriteLine("Horizontal winner found !");
               break;
            }
            else if ( vCount == root )
            { 
               Console.WriteLine("Virtical winner found !");
               break;
            }
        }
    }
