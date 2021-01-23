	int rows=Convert.ToInt32(Console.ReadLine());
	int [,] multiDynamic=new int[rows,columns];
	for(int i=0;i<rows;i++)
	{
		Console.WriteLine("Enter no of columns for "+i+" row");
		   var columns  = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("enter " +i+ " row elements");
		for(int j=0;j<columns;j++)
		{
			multiDynamic[i,j]=Convert.ToInt32(Console.ReadLine());
		}
	}
	Console.WriteLine("The array elements are ");
