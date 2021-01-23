     class Program
        {
            static void Main(string[] args)
            {
                PrintItems(Search("John Lennon"));
                PrintFileName(Search("John Lennon"));
                Console.Read();
            }
    
            static string[] Search(string var)
            {
                return Directory.GetFiles(@"K:\mp3", "*" + var + "*.mp3", SearchOption.AllDirectories);
            }
    
            static void PrintItems(string[] array)
            {
                for (int i = 0; i < array.Length; i++)
                    Console.Write(array[i] + "\n");
            }
    
            static void PrintFileName(string[] array)
            {
                foreach (var item in array)
                {
                    FileInfo fi = new FileInfo(item);
                    Console.WriteLine(fi.Name);
                }
            }
        }
