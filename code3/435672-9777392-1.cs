        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("filename.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                var fields = lines[i].Split(' ');
            }
        }
