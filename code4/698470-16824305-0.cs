    static void Main(string[] args)
    {
        // load MAT-file contents into a structure variable
        matlab.Execute("S = load('wind.mat')");
        
        // get field and store in separate variable
        matlab.Execute("x = S.x;");
        
        // obtain variable "x" from MATLAB into C#
        var x = (double[,,]) matlab.GetVariable("x", "base");
        
        // print array in C#
        Console.WriteLine("ndims(x) = {0}, numel(x) = {1}", x.Rank, x.Length);
        for (int i = 0; i < x.GetLength(0); i++)
        {
            for (int j = 0; j < x.GetLength(1); j++)
            {
                for (int k = 0; k < x.GetLength(2); k++)
                {
                    Console.WriteLine("x[{0},{1},{2}] = {3}", i, j, k, x[i,j,k]);
                }
            }
        }
    }
