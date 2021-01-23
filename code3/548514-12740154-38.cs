    class Program
    {
        static void Main(string[] args)
        {
            //display fourier
            foreach (var item in Fourier.DFT(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }))
            {
                Console.WriteLine(item);
            }
        }
    }
