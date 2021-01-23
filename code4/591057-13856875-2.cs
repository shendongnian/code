    static void foo(int[,] arr, Func<int,int> arg1)
    {
        //say arg1 = row - 1
    
        for(int row = 0; row < arr.GetLength(0); row++)
        {  
             for(int col = 0; col < arr.GetLength(1); col++)
             {
                 int newRow = arg1(row);
                 MessageBox.Show(arr[newRow, col]) // should be equal to arr[row-1,col]
             }
        }
    }
