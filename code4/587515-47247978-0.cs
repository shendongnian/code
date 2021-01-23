	public static void Main()
	{
		int a,b=0;
		int []arr={1, 2, 2, 3, 3, 4, 5, 6, 5, 7, 7, 7, 100, 8, 1};
		
		for(int i=arr.Length-1 ; i>-1 ; i--)
			{
				a = arr[i];
				
				if(a > b)
				{
					b=a;	
				}
			}
		Console.WriteLine(b);
	}
