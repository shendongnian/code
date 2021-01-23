    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                Process.Start(@"c:\temp\presentation1.pptx").WaitForExit();
            }).ContinueWith(o => 
            {
                Process.Start(@"c:\temp\presentation2.pptx").WaitForExit();
            });
            Console.ReadKey();
        }       
    }
