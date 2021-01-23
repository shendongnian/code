    public class MyCustomComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            // split filename
            string[] parts1 = x.Name.Split('-');
            string[] parts2 = y.Name.Split('-');
            // calculate how much leading zeros we need
            int toPad1 = 10 - parts1[0].Length;
            int toPad2 = 10 - parts2[0].Length;
 
            // add the zeros, only for sorting
            parts1[0] = parts1[0].Insert(0, new String('0', toPad1));
            parts2[0] = parts2[0].Insert(0, new String('0', toPad2));
            // create the comparable string
            string toCompare1 = string.Join("", parts1);
            string toCompare2 = string.Join("", parts2);
            // compare
            return toCompare1.CompareTo(toCompare2);
        }
    }
