    internal class Program
    {
        static void Main(string[] args)
        {
            string fullPath = GetExactPathFromEnvironmentVar("ping.exe");
            if (!string.IsNullOrWhiteSpace(fullPath))
                Console.WriteLine(fullPath);
            else
                Console.WriteLine("Not found");
        }
        static string GetExactPathFromEnvironmentVar(string program)
        {
            var pathVar = System.Environment.GetEnvironmentVariable("PATH");
            string[] folders = pathVar.Split(';');
            foreach (var folder in folders)
            {
                string path = Path.Combine(folder, program);
                if (File.Exists(path))
                {
                    return path;
                }
            }
            return null;
        }
    }
