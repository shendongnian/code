    int numbers[] = new int[] { 1,2,1,2,1,2,1,2,1,2,1,2,1,2,2,2,1,2,1 };
      
       int count = 0;
       int updownup = 0;
       int downupdown = 0;
       for(int x = 0;x<=numbers.Length;x++)
       {
          if(x<numbers.Length - 2)
          {
             if(numbers[x]<numbers[x+1])
             {
              if(numbers[x+1]>numbers[x+2])
               {
               downupdown++; 
                }
             }
           
        }
    }
    count = 0;
    for(x=0;x<=numbers.Length;x++)
    {
      if(x<numbers.Length - 2)
      {
        if(numbers[x]>numbers[x+1]
        {
         if(numbers[x+1]<numbers[x+2])
         {
            updownup++;
            }
        }
        }
        
    }
