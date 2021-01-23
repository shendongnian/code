    static void Main(string[] args)
    {
        var x = GetPasVal(3, 2);
        Console.WriteLine(x);
    }
    public static long GetPasVal(int row, int col)
    {
        int factOfRow = 1,i;
        for(i = 1;i<=(row - 1);i++)
            factOfRow *= i;
        int factOfRowMinusCol = 1;
        for(i = 1;i<=(row - 1)- (col - 1);i++)//check out below link to understand condition 
             factOfRowMinusCol *= i;
        int factOfCol = 1;     
        for(i = 1;i<= (col - 1);i++)
            factOfCol *=i;   
        int fact = factOfRow / (factOfCol * factOfRowMinusCol);
        return fact;
    }
    https://www.mathsisfun.com/pascals-triangle.html
