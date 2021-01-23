    using System;
    using System.Collections.Generic;
					
    public class Program
    {
	  public void Main()
       {		
		for(int i =0 ; i<5;i++)
		{
			int sum = 1;
			Console.WriteLine();
			for(int j =0 ; j<=i;j++)
			{
				Console.Write(pascal(i,j));
				//Console.Write(sum); //print without recursion
				sum= sum *(i-j) / (j + 1);				
			}
		}			
    }
	
	  public int pascal(int x, int y)
	  {
		if((x+1)==1 || (y+1)==1 || x==y)
		{
			return 1;
		}
		else
		{
			return pascal(x-1,y-1)+ pascal(x-1,y);
		}
	  }
    }
