    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = 3;
            string[,] matrix = new string[matrixSize,matrixSize];
            //create square matrix
            for (int x = 0; x < matrixSize; x++)
            {
                for (int y = 0; y < matrixSize; y++)
                {
                    matrix[x, y] = "a" + (x + 1).ToString() + (y + 1).ToString();
                }
            }
            Console.WriteLine(Environment.NewLine + "Base square matrix");
            
            for (int x = 0; x < matrixSize; x++)
            {              
                for (int y = 0; y < matrixSize; y++)
                {
                    Console.Write(matrix[x, y] + " ");
                }
                Console.Write(Environment.NewLine);
            }
            Console.ReadKey();
            //copy diagonals
            string[] leftDiagonal = new string[matrixSize];
            string[] rightDiagonal = new string[matrixSize];
            for (int x = 0; x < matrixSize; x++)
            {
                leftDiagonal[x] = matrix[x, x];
                rightDiagonal[x] = matrix[matrixSize - 1 - x, x];
            }
            Console.WriteLine(Environment.NewLine + "Diagonals");
            for (int x = 0; x < matrixSize; ++x)
            {
                Console.Write(leftDiagonal[x] + " " + rightDiagonal[x] + Environment.NewLine);
            }
            Console.ReadKey();
            //rotate matrix
            string[,] rotatedMatrix = new string[matrixSize, matrixSize];
            for (int x = 0; x < matrixSize; x++)
            {
                for (int y = 0; y < matrixSize; y++)
                {
                    rotatedMatrix[x, y] = matrix[matrixSize - y - 1, x];
                }
            }
            Console.WriteLine(Environment.NewLine + "Rotated");
            for (int x = 0; x < matrixSize; x++)
            {
                for (int y = 0; y < matrixSize; y++)
                {
                    Console.Write(rotatedMatrix[x, y] + " ");
                }
                Console.Write(Environment.NewLine);
            }
            Console.ReadKey();
            //rotate matrix again
            string[,] rotatedMatrixAgain = new string[matrixSize, matrixSize];
            for (int x = 0; x < matrixSize; x++)
            {
                for (int y = 0; y < matrixSize; y++)
                {
                    rotatedMatrixAgain[x, y] = rotatedMatrix[matrixSize - y - 1, x];
                }
            }
            Console.WriteLine(Environment.NewLine + "Rotated again");
            for (int x = 0; x < matrixSize; x++)
            {
                for (int y = 0; y < matrixSize; y++)
                {
                    Console.Write(rotatedMatrixAgain[x, y] + " ");
                }
                Console.Write(Environment.NewLine);
            }
            Console.ReadKey();
            //replace diagonals
            for (int x = 0; x < matrixSize; x++)
            {
                rotatedMatrixAgain[x, x] = leftDiagonal[x];
                rotatedMatrixAgain[matrixSize - 1 - x, x] = rightDiagonal[x];
            }
            Console.WriteLine(Environment.NewLine + "Completed" + Environment.NewLine);
            for (int x = 0; x < matrixSize; x++)
            {
                for (int y = 0; y < matrixSize; y++)
                {
                    Console.Write(rotatedMatrixAgain[x, y] + " ");
                }
                Console.Write(Environment.NewLine);
            }
            Console.ReadKey();
        }
    }
