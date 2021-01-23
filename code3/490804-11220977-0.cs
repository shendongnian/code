    int [,] multiDynamic = null;
    for(int i=0;i<rows;i++)
            {
    
                Console.WriteLine("Enter no of columns for "+i+" row");
                var columns  = Convert.ToInt32(Console.ReadLine());
                 multiDynamic=new int[rows,columns];
                Console.WriteLine("enter " +i+ " row elements");
                for(int j=0;j<columns;j++)
                {
                    multiDynamic[i,j]=Convert.ToInt32(Console.ReadLine());
                }
    
    
            }
