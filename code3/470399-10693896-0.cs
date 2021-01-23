    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var cd = Directory.GetCurrentDirectory();
                Directory.CreateDirectory(cd + @"\5app\");
                File.Copy(@"c:\xyz.txt", cd + @"\5app\xyz.txt");
            }
        }
    }
