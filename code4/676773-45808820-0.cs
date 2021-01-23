    using System.IO;
    using System.Linq;
        /// <summary>
        /// Add a new line at a specific position in a simple file        
        /// </summary>
        /// <param name="fileName">Complete file path</param>
        /// <param name="lineToSearch">Line to search in the file (first occurrence)</param>
        /// <param name="lineToAdd">Line to be added</param>
        /// <param name="aboveBelow">insert above(false) or below(true) of the search line. Default: above </param>
        internal static void insertLineToSimpleFile(string fileName, string lineToSearch, string lineToAdd, bool aboveBelow = false)
        {          
            var txtLines = File.ReadAllLines(fileName).ToList();
            int index = aboveBelow?txtLines.IndexOf(lineToSearch)+1: txtLines.IndexOf(lineToSearch);
            if (index > 0)
            {
                txtLines.Insert(index, lineToAdd);
                File.WriteAllLines(fileName, txtLines);
            }
        }
