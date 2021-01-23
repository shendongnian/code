    using System.IO;
    using System.Linq;
    namespace FileSorter
    {
        class Program
        {
            static void Main(string[] args)
            {
                var fieldToSortBy = 0;
                
                //data.txt contains lines like 114765 * 3 * 659300 * 01 * 17/01/2013 * * 1 * Chuck Norris * Chuck Norris Jr* Owner * 1 * 28/04/1983 * Conjuge * * * 16/1/2013 * 1 * Quadro Social *
                var lines = File.ReadAllLines(@"C:\temp\data.txt");
                var splitLines = lines.Select(l => l.Split('*'));
                var orderedLines = splitLines.OrderByDescending(l => int.Parse(l[fieldToSortBy].Trim()));
                var joinedLines = orderedLines.Select(l => string.Join("*", l));
                File.WriteAllLines(@"C:\temp\output.txt", joinedLines);
            }
        }
    }
